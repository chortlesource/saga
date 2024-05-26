using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Saga.Debug
{
    internal class Terminal
    {
        public static bool IsDebugMode { get; } = Debugger.IsAttached;

        /// <summary>
        /// Prints a formatted Log message to the terminal
        /// </summary>
        /// <param name="msg">The log message to be printed</param>
        public static void Log(string msg)
        {
            if (IsDebugMode)
            {
                Console.WriteLine($"[DBUG] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {msg}");
            }
        }

        /// <summary>
        /// Prints a formatted Info message to the terminal
        /// </summary>
        /// <param name="msg">The information message to be printed</param>
        public static void Info(string msg)
        {
            if (IsDebugMode)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {msg}");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Prints a formatted Warning message to the terminal
        /// </summary>
        /// <param name="msg">The warning message to be printed</param>
        public static void Warn(string msg)
        {
            if (IsDebugMode)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"[WARN] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {msg}");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Prints a formatted Error message to the terminal
        /// </summary>
        /// <param name="msg">The error message to be printed</param>
        public static void Err(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ERRR] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {msg}");
            Console.ResetColor();
        }
    }
}
