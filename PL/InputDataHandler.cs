using System;
using System.Globalization;
using BLL;

namespace PL
{
    public static class InputDataHandler
    {
        public static void SetSerializationType(SerializationService serializationService)
        {
            Console.WriteLine("1 - Бінарна;\n" +
                              "2 - XML;\n" +
                              "3 - JSON;\n" +
                              "4 - Користувацька.");
            var type = ConsoleWorker.ReadItem(foregroundColor: ConsoleColor.Cyan);
            var checker = new RegexChecker(type, @"^[1-4]$");
            serializationService.SetSerializationType(int.Parse(checker.Check(ConsoleColor.Cyan)));
            ConsoleWorker.NewLine();
        }

        public static void SetPath(SerializationService serializationService)
        {
            Console.WriteLine("Введіть шлях для збереження результатів сериалізацї, або залиште його за замовченням (Enter):");
            var path = ConsoleWorker.ReadItem(foregroundColor: ConsoleColor.Cyan);
            var checker = new RegexChecker(path, @"(^([a-zA-Z]:)?(\\[a-zA-Zа-яА-ЯіІїЇ\s0-9_\-]+)+\\?)|(^$|\s+/)");
            serializationService.SetConnection(checker.Check(ConsoleColor.Cyan));
            ConsoleWorker.NewLine();
        }

        public static void SetFileName(SerializationService serializationService)
        {
            Console.WriteLine("Введіть ім'я файлу, або нічого не вводьте (Enter):");
            var name = ConsoleWorker.ReadItem(foregroundColor: ConsoleColor.Cyan);
            var checker = new RegexChecker(name, @"^[^<>:""/\\|?*]*$");
            serializationService.SetName(checker.Check(ConsoleColor.Cyan));
            ConsoleWorker.NewLine();
        }

        public static string InputName(string name)
        {
            return InputData($"Введіть {name}: ", @"(^[A-Z]{1}[a-z]+$)|(^[А-ЯЇЬІ]{1}[а-яїьі]+$)");
        }

        public static string InputCourse()
        {
            return InputData("Введіть курс (1-6): ", @"^[1-6]{1}?");
        }

        public static string InputStudentId()
        {
            return InputData("Введіть ID студента (фомат: AB12345678): ", @"^[A-Z]{2}[0-9]{8}$");
        }

        public static double InputStudentGpa()
        {
            var formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return double.Parse(InputData("Введіть середій бал студента (0.00 - 100.00): ",
                @"(^[0-9]{1,2}\.[0-9]{2})|(100\.00)"), formatter);
        }

        public static string InputCountry()
        {
            return InputData("Введіть країну проживання: ", @"(^[A-Z]{1}[a-z]+$)|(^[А-ЯЇЬІ]{1}[а-яїьі]+$)");
        }

        public static string InputNumberOfScorebook()
        {
            return InputData("Введіть номер залікової книжки (формат: 12345678): ", @"^[0-9]{8}$");
        }

        public static string InputSalary()
        {
            return InputData("Введіть зарплату (формат: $123,22): ", @"^\$[0-9]{1,3}\,[0-9]{2}$");
        }

        public static bool InputDiploma()
        {
            var valueString = InputData("Чи має диплом? (T/F, Т/Н, Yes/No, Так/Ні): ",
                @"(^[YN|ТН]{1}$)|(^(Yes|No)|(Так|Ні){1}$)");
            return valueString == "T" || valueString == "Т" || valueString == "Yes" || valueString == "Так" || valueString == "";
        }

        public static string InputCountOfSubordinates()
        {
            return InputData("Введіть кількість підлеглих (0-99999): ", @"^[0-9]{0,5}$");
        }

        private static string InputData(string message, string rule)
        {
            ConsoleWorker.WriteItem(message, false);
            var name = ConsoleWorker.ReadItem(foregroundColor: ConsoleColor.Yellow);
            if (name == string.Empty) return name;
            var checker = new RegexChecker(name, rule);
            return checker.Check(ConsoleColor.Yellow);
        }
    }
}