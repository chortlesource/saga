using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Saga.Debug
{
    public static class Term
    {
        public static bool IsDebugMode { get; } = Debugger.IsAttached;

        /// <summary>
        /// Prints message out for debugging
        /// </summary>
        /// <param name="msg">The log message to be printed</param>
        public static void Debug(string msg)
        {
            if (IsDebugMode)
            {
                System.Diagnostics.Debug.WriteLine($"[DBUG] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {msg}");
            }
        }
    }
}
