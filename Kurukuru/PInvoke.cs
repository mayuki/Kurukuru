using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Kurukuru
{
    internal static class PInvoke
    {
        private const string Kernel32 = "kernel32.dll";

        internal enum StdHandle : int
        {
            STD_OUTPUT_HANDLE = -11,
        }

        internal enum ConsoleMode : int
        {
            ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,
        }

        [DllImport(Kernel32)]
        internal static extern IntPtr GetStdHandle(StdHandle nStdHandle);

        [DllImport(Kernel32, SetLastError = true)]
        internal static extern bool GetConsoleMode(IntPtr handle, out ConsoleMode mode);

        [DllImport(Kernel32, SetLastError = true)]
        internal static extern bool SetConsoleMode(IntPtr handle, ConsoleMode mode);
    }
}
