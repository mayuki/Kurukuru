using System;

namespace Kurukuru
{
    internal static class ConsoleHelper
    {
        public static bool ShouldFallback
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Win32NT &&
                    (Console.OutputEncoding.CodePage != 1200 /* UTF-16 */ && Console.OutputEncoding.CodePage != 65001 /* UTF-8 */);
            }
        }

        public static bool CanAcceptEscapeSequence
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Unix;
            }
        }

        public static void WriteWithColor(string s, ConsoleColor color)
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(s);
            Console.ForegroundColor = foregroundColor;
        }

        // See: https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console/8946847#8946847
        public static void ClearCurrentConsoleLine(int length)
        {
            if (Console.IsOutputRedirected || length == 0) return;

            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', length));
            Console.SetCursorPosition(0, currentLineCursor);
            Console.Out.Flush();
        }

        public static void SetCursorVisibility(bool visible)
        {
            if (!CanAcceptEscapeSequence) return;

            if (visible)
            {
                Console.Write("\u001B[?25h");
            }
            else
            {
                Console.Write("\u001B[?25l");
            }
        }
    }
}
