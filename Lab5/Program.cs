using PL;
using System;
using System.Text;

namespace Lab3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            Console.InputEncoding = Encoding.Default;

            var menu = new Menu();
            menu.MainMenu();
        }
    }
}
