using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kurukuru
{
    public class Spinner : IDisposable
    {
        private static readonly object s_consoleLock;
        private static int s_runningSpinnerCount;

        static Spinner()
        {
            // try get internal Console's lock object( .NET 6 )
            var lockObject = typeof(Console).GetField("s_syncObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (lockObject != null)
            {
                s_consoleLock = lockObject;
            }
            else
            {
                s_consoleLock = new object();
            }
        }

        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly bool _enabled;
        private Task? _task;
        private Pattern _pattern;
        private Pattern _fallbackPattern;
        private int _frameIndex;
        private int _lineLength;
        private int _cursorTop;

        public bool Stopped { get; private set; }
        public SymbolDefinition SymbolSucceed { get; set; } = new SymbolDefinition("✔", "O");
        public SymbolDefinition SymbolFailed { get; set; } = new SymbolDefinition("✖", "X");
        public SymbolDefinition SymbolWarn { get; set; } = new SymbolDefinition("⚠", "[!]");
        public SymbolDefinition SymbolInfo { get; set; } = new SymbolDefinition("ℹ", "[i]");

        public ConsoleColor? Color { get; set; }
        public string Text { get; set; }

        private static Pattern DefaultPattern
        {
            get
            {
                return ConsoleHelper.ShouldFallback
                    ? Patterns.Line
                    : Patterns.Dots;
            }
        }

        private Pattern CurrentPattern
        {
            get
            {
                return ConsoleHelper.ShouldFallback
                    ? _fallbackPattern
                    : _pattern;
            }
        }

        public Spinner(string text, Pattern? pattern = null, ConsoleColor? color = null, bool enabled = true, Pattern? fallbackPattern = null)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _pattern = pattern ?? DefaultPattern;
            _fallbackPattern = fallbackPattern ?? DefaultPattern;
            _enabled = enabled && !ConsoleHelper.IsRunningOnCI && !Console.IsOutputRedirected /* isatty */;

            Text = text;
            Color = color;
        }

        public void Start()
        {
            Start(Environment.NewLine);
        }

        public void Start(string terminator)
        {
            if (!_enabled) return;
            if (_task != null) throw new InvalidOperationException("Spinner is already running");

            Stopped = false;
            lock (s_consoleLock)
            {
                lock (Console.Out)
                {
                    if (s_runningSpinnerCount == 0)
                    {
                        ConsoleHelper.TryEnableEscapeSequence();
                        ConsoleHelper.SetCursorVisibility(false);
                    }
                    s_runningSpinnerCount++;
                    _cursorTop = Console.CursorTop;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                }
            }

            _task = Task.Run(async () =>
            {
                _frameIndex = 0;
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    Render(terminator);
                    await Task.Delay(CurrentPattern.Interval).ConfigureAwait(false);
                }
            });
        }

        private void Render(string terminator)
        {
            var pattern = CurrentPattern;
            var frame = pattern.Frames[_frameIndex++ % pattern.Frames.Length];

            lock (s_consoleLock)
            {
                lock (Console.Out)
                {
                    var currentLeft = Console.CursorLeft;
                    var currentTop = Console.CursorTop;

                    ConsoleHelper.ClearCurrentConsoleLine(_lineLength, _enabled ? _cursorTop : currentTop);
                    ConsoleHelper.WriteWithColor(frame, Color ?? Console.ForegroundColor);
                    Console.Write(" ");
                    Console.Write(Text);
                    _lineLength = Console.CursorLeft; // get line length before write terminator
                    Console.Write(terminator);
                    Console.Out.Flush();

                    if (_enabled)
                    {
                        Console.SetCursorPosition(currentLeft, currentTop);
                    }
                }
            }
        }

        public void Dispose()
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                Stop(symbol: null, color: null);
            }
        }

        public void Stop(string? text = null, string? symbol = null, ConsoleColor? color = null)
        {
            Stop(text, symbol, color, Environment.NewLine);
        }

        public void Stop(string? text, string? symbol, ConsoleColor? color, string terminator)
        {
            if (_cancellationTokenSource.IsCancellationRequested) return;

            _cancellationTokenSource.Cancel();
            _task?.Wait();

            Color = color ?? Color;
            Text = text ?? Text;
            Stopped = true;

            _pattern = _fallbackPattern = new Pattern(new[] { symbol ?? " " }, 1000);
            lock (s_consoleLock)
            {
                Render(terminator);
                if (_enabled)
                {
                    s_runningSpinnerCount--;
                    if (s_runningSpinnerCount == 0)
                    {
                        ConsoleHelper.SetCursorVisibility(true);
                    }
                }
            }
        }

        public void Succeed(string? text = null)
        {
            Stop(text, ConsoleHelper.ShouldFallback ? SymbolSucceed.Fallback : SymbolSucceed.Default, ConsoleColor.Green);
        }

        public void Fail(string? text = null)
        {
            Stop(text, ConsoleHelper.ShouldFallback ? SymbolFailed.Fallback : SymbolFailed.Default, ConsoleColor.Red);
        }

        public void Warn(string? text = null)
        {
            Stop(text, ConsoleHelper.ShouldFallback ? SymbolWarn.Fallback : SymbolWarn.Default, ConsoleColor.Yellow);
        }

        public void Info(string? text = null)
        {
            Stop(text, ConsoleHelper.ShouldFallback ? SymbolInfo.Fallback : SymbolInfo.Default, ConsoleColor.Blue);
        }

        public static void Start(string text, Action action, Pattern? pattern = null, Pattern? fallbackPattern = null)
        {
            Start(text, _ => action(), pattern, fallbackPattern);
        }

        public static void Start(string text, Action<Spinner> action, Pattern? pattern = null, Pattern? fallbackPattern = null)
        {
            using (var spinner = new Spinner(text, pattern, fallbackPattern: fallbackPattern))
            {
                spinner.Start();

                try
                {
                    action(spinner);

                    if (!spinner.Stopped)
                    {
                        spinner.Succeed();
                    }
                }
                catch
                {
                    if (!spinner.Stopped)
                    {
                        spinner.Fail();
                    }
                    throw;
                }
            }
        }

        public static Task StartAsync(string text, Func<Task> action, Pattern? pattern = null, Pattern? fallbackPattern = null)
        {
            return StartAsync(text, _ => action(), pattern, fallbackPattern);
        }

        public static async Task StartAsync(string text, Func<Spinner, Task> action, Pattern? pattern = null, Pattern? fallbackPattern = null)
        {
            using (var spinner = new Spinner(text, pattern, fallbackPattern: fallbackPattern))
            {
                spinner.Start();

                try
                {
                    await action(spinner).ConfigureAwait(false);
                    if (!spinner.Stopped)
                    {
                        spinner.Succeed();
                    }
                }
                catch
                {
                    if (!spinner.Stopped)
                    {
                        spinner.Fail();
                    }
                    throw;
                }
            }
        }

        public static Task<TResult> StartAsync<TResult>(string text, Func<Task<TResult>> action, Pattern? pattern = null, Pattern? fallbackPattern = null)
        {
            return StartAsync(text, _ => action(), pattern, fallbackPattern);
        }

        public static async Task<TResult> StartAsync<TResult>(string text, Func<Spinner, Task<TResult>> action, Pattern? pattern = null, Pattern? fallbackPattern = null)
        {
            using (var spinner = new Spinner(text, pattern, fallbackPattern: fallbackPattern))
            {
                spinner.Start();

                try
                {
                    var result = await action(spinner).ConfigureAwait(false);
                    if (!spinner.Stopped)
                    {
                        spinner.Succeed();
                    }

                    return result;
                }
                catch
                {
                    if (!spinner.Stopped)
                    {
                        spinner.Fail();
                    }
                    throw;
                }
            }
        }
    }
}
