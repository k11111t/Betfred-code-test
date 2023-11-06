using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTest
{
    public static class ConsoleLog
    {
        public static void LogHeader(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"---------- {text} ----------");
            Console.WriteLine("");
            Console.ResetColor();
        }

        public static void LogText(string text)
        {
            Console.WriteLine(text);
        }

        public static void LogResult(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine(text);
            Console.WriteLine("");
            Console.ResetColor();
        }

        internal static void LogSub(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"*{text}*");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}
