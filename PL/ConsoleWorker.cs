using System;

namespace PL
{
    public static class ConsoleWorker
    {
        public static void WriteItem(object obj = null, bool newLine = true, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(obj + (newLine ? "\n" : ""));
            Console.ResetColor();
        }
        public static void WriteItem(string str = "", bool newLine = true, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(str + (newLine ? "\n" : ""));
            Console.ResetColor();
        }

        public static void NewLine() => Console.WriteLine();

        public static string ReadItem(bool newLine = false, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            var text = Console.ReadLine();
            Console.Write(newLine ? "\n" : "");
            Console.ResetColor();
            return text;
        }
        public static void Clear() => Console.Clear();
    }
}