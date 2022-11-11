using System;
using System.Text.RegularExpressions;

namespace PL
{
    public class RegexChecker
    {
        private string _data;
        private readonly string _format;

        public RegexChecker(string data, string format)
        {
            _data = data; _format = format;
        }

        public string Check(ConsoleColor color = ConsoleColor.White)
        {
            var regex = new Regex(_format);
            while (!regex.IsMatch(_data))
            {
                ConsoleWorker.WriteItem("Значення невірне. Будь ласка, введіть ще раз", foregroundColor: ConsoleColor.Red);
                _data = ConsoleWorker.ReadItem(foregroundColor: color);
            }
            return _data;
        }
    }
}