using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kurukuru.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            // for (var i = 0; i < 10000; i++) { Console.WriteLine(i); }

            using (var spinner = new Spinner("Initializing...", Patterns.Dots12))
            {
                spinner.Start();
                await Task.Delay(2000);
                spinner.Succeed();
            }

            await Spinner.StartAsync("ユーザー Alice でログインを試みています…", async spinner =>
            {
                await Task.Delay(1000);
                spinner.Text = "こんにちは Alice!";
            });

            try
            {
                await Spinner.StartAsync("Executing some heavy task...", async () =>
                {
                    await Task.Delay(3000);
                    throw new Exception();
                });
            }
            catch
            {
            }

            var cts = new CancellationTokenSource(5000);
            var count = 0;
            Task CreateThreadingSpinner(int number) => Spinner.StartAsync($"Threading {number}…", async spinner =>
            {
                await Task.Delay(1000);
                while (!cts.IsCancellationRequested)
                {
                    await Task.Yield();
                    spinner.Text = $"Threading {number} processing " + Interlocked.Increment(ref count);
                }
            });

            var otherCount = 0;
            _ = Task.Run(async () =>
            {
                while (!cts.IsCancellationRequested)
                {
                    await Task.Delay(1500);
                    Console.WriteLine("other logging " + Interlocked.Increment(ref otherCount));
                }
            });

            var one = CreateThreadingSpinner(1);
            var two = CreateThreadingSpinner(2);
            var three = CreateThreadingSpinner(3);

            var more = Task.Run(async () =>
            {
                await Task.Delay(2000);

                var four = CreateThreadingSpinner(4);
                var five = CreateThreadingSpinner(5);
                await Task.WhenAll(four, five);
            });

            await Task.WhenAll(one, two, three, more);
            Console.WriteLine("Complete");
        }
    }
}
