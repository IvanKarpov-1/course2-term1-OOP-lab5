using BLL;
using Exceptions;
using System;
using System.Linq;

namespace PL
{
    public class Menu
    {
        private readonly DataStorage _storage;
        private readonly EntityService _entityService;
        private readonly SerializationService _serializationService;

        public Menu()
        {
            _storage = new DataStorage();
            _entityService = new EntityService();
            _serializationService = new SerializationService();
        }

        public void MainMenu()
        {
            ConsoleWorker.WriteItem("Виберіть тип серіалізації");
            InputDataHandler.SetSerializationType(_serializationService);
            InputDataHandler.SetPath(_serializationService);
            InputDataHandler.SetFileName(_serializationService);

            while (true)
            {
                ConsoleWorker.Clear();

                switch (ChooseAction())
                {
                    case "1":
                    {
                        StudentMenu();
                        break;
                    }
                    case "2":
                    {
                        ManagerMenu();
                        break;
                    }
                    case "3":
                    {
                        McdonaldsWorkerMenu();
                        break;
                    }
                    case "4":
                    {
                        InputDataHandler.SetSerializationType(_serializationService);
                        break;
                    }
                    case "5":
                    {
                        InputDataHandler.SetPath(_serializationService);
                        break;
                    }
                    case "6":
                    {
                        InputDataHandler.SetFileName(_serializationService);
                        break;
                    }
                    case "7":
                    {
                        Environment.Exit(0);
                        break;
                    }
                    default:
                    {
                        ConsoleWorker.WriteItem("Вибір не вірний. Виберіть ще раз!", foregroundColor: ConsoleColor.Red);
                        break;
                    }
                }
            }
        }

        public string ChooseAction()
        {
            ConsoleWorker.WriteItem("Виберіть людину:\n" +
                                    "1 - Студент;\n" +
                                    "2 - Менеджер;\n" +
                                    "3 - Працівник МакДональдсу.\n\n" +
                                    "Інші дії:\n" +
                                    "4 - Змінити тип сериалізації;\n" +
                                    "5 - Змінити шлях;\n" +
                                    "6 - Змінити ім'я файлу;\n" +
                                    "7 - Вийти з програми.");
            return ConsoleWorker.ReadItem(true, foregroundColor: ConsoleColor.Cyan);
        }

        public void StudentMenu()
        {
            _entityService.Persons = _storage.Students;

            ConsoleWorker.Clear();

            var flag = true;
            while (flag)
            {
                ConsoleWorker.WriteItem("Виберіть дію:\n" +
                                        "1 - Додати студента;\n" +
                                        "2 - Видалити студента;\n" +
                                        "3 - Показати список студентів;\n" +
                                        "4 - Знайти студента;\n" +
                                        "5 - Знайти та вивести студентів третього курсу, які проживають в Україні;\n" +
                                        "6 - Очистити дані;\n" +
                                        "7 - Серіалізувати;\n" +
                                        "8 - Десеріалізувати;\n" +
                                        "9 - Повернутися назад.");

                switch (ConsoleWorker.ReadItem(true, foregroundColor: ConsoleColor.Cyan))
                {
                    case "1":
                    {
                        ConsoleWorker.Clear();

                        var firstName = InputDataHandler.InputName("ім'я"); 
                        var lastName = InputDataHandler.InputName("фамілію");
                        var country = InputDataHandler.InputCountry();
                        var course = InputDataHandler.InputCourse();
                        var studentId = InputDataHandler.InputStudentId();
                        var numberOfScorebook = InputDataHandler.InputNumberOfScorebook();
                        var gpa = InputDataHandler.InputStudentGpa();

                        var currentStudent = new CurrentStudent(firstName: firstName, lastName: lastName, course, studentId, gpa, country,
                            numberOfScorebook);

                        _entityService.Add(currentStudent);
                        
                        ConsoleWorker.Clear();

                        break;
                    }
                    case "2":
                    {
                        ConsoleWorker.Clear();

                        ConsoleWorker.WriteItem("Введіть відому інформацію про студента, якого потрібно видалити.\n" +
                                                "Інакше нічого не вводьте і видалиться перший в списку студент.");

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var country = InputDataHandler.InputCountry();
                        var course = InputDataHandler.InputCourse();
                        var studentId = InputDataHandler.InputStudentId();
                        var numberOfScorebook = InputDataHandler.InputNumberOfScorebook();

                        var options = new SearchOptions(firstName, lastName, studentId, numberOfScorebook, course, country);

                        try
                        {
                            var searchResult = _entityService.Find(options);
                            _entityService.Remove(searchResult);
                            ConsoleWorker.WriteItem("Студента видалено.", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (StudentNotFountException)
                        {
                            ConsoleWorker.WriteItem("Збігів для видалення не знайдено.", foregroundColor: ConsoleColor.DarkCyan);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "3":
                    {
                        ConsoleWorker.Clear();

                        try
                        {
                            var students = _entityService.Persons.GetData();
                            var i = 1;
                            foreach (var student in students)
                            {
                                ConsoleWorker.WriteItem($"{i}) {student}", foregroundColor: ConsoleColor.Green);
                                i++;
                            }
                        }
                        catch (StudentNotFountException)
                        {
                            ConsoleWorker.WriteItem("Список порожній.", foregroundColor: ConsoleColor.DarkCyan);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "4":
                    {
                        ConsoleWorker.Clear();

                        ConsoleWorker.WriteItem("Введіть відому інформацію про студента, якого потрібно знайти.\n" +
                                                "Інакше нічого не вводьте і виведеться перший в списку студент.");

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var country = InputDataHandler.InputCountry();
                        var course = InputDataHandler.InputCourse();
                        var studentId = InputDataHandler.InputStudentId();
                        var numberOfScorebook = InputDataHandler.InputNumberOfScorebook();

                        var options = new SearchOptions(firstName, lastName, studentId, numberOfScorebook, course, country);

                        ConsoleWorker.NewLine();

                        try
                        {
                            ConsoleWorker.WriteItem(_entityService.Find(options), foregroundColor: ConsoleColor.Green);
                        }
                        catch (StudentNotFountException)
                        {
                            ConsoleWorker.WriteItem("Студента не знайдено.", foregroundColor: ConsoleColor.Green);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "5":
                    {
                        ConsoleWorker.Clear();

                        var options1 = new SearchOptions(course: "3", country: "Ukraine");
                        var options2 = new SearchOptions(course: "3", country: "Україна");

                        try
                        {
                            var searchResult = _entityService.FindAll(options1).Concat(_entityService.FindAll(options2)).ToList();
                            ConsoleWorker.WriteItem($"Студентів третього курсу, що проживають в Україні - {searchResult.Count}:");
                            var i = 1;
                            foreach (var student in searchResult)
                            {
                                ConsoleWorker.WriteItem($"{i}) {student}", foregroundColor: ConsoleColor.Green);
                                i++;
                            }
                        }
                        catch (StudentNotFountException)
                        {
                            ConsoleWorker.WriteItem("Збігів не знайдено.", foregroundColor: ConsoleColor.Green);
                        }
                        
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "6":
                    {
                        _entityService.Clear();
                           
                        ConsoleWorker.Clear();
                        ConsoleWorker.WriteItem("Список очищено.", foregroundColor: ConsoleColor.DarkCyan);
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "7":
                    {
                        try
                        {
                            ConsoleWorker.Clear();
                            _serializationService.SerializeStudents(_entityService);
                            ConsoleWorker.WriteItem("Серіалізація пройшла успісно", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (Exception exception)
                        {
                            ConsoleWorker.WriteItem(exception.Message, foregroundColor: ConsoleColor.DarkRed);
                        }
                            
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "8":
                    {
                        try
                        {
                            ConsoleWorker.Clear();
                            _serializationService.DeserializeStudents(_entityService);
                            ConsoleWorker.WriteItem("Десеріалізація пройшла успісно", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (Exception exception)
                        {
                            ConsoleWorker.WriteItem(exception.Message, foregroundColor: ConsoleColor.DarkRed);
                        }
                            
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "9":
                    {
                        flag = false;
                        break;
                    }
                    default:
                    {
                        ConsoleWorker.WriteItem("Дія вибрана невірно!", foregroundColor: ConsoleColor.Red);
                        break;
                    }
                }
            }
        }

        public void ManagerMenu()
        {
            _entityService.Persons = _storage.Managers;

            ConsoleWorker.Clear();

            var flag = true;
            while (flag)
            {
                ConsoleWorker.WriteItem("Виберіть дію:\n" +
                                        "1 - Додати менеджера;\n" +
                                        "2 - Видалити менеджера;\n" +
                                        "3 - Показати список менеджерів;\n" +
                                        "4 - Знайти менеджера;\n" +
                                        "5 - Очистити список;\n" +
                                        "6 - Серіалізувати;\n" +
                                        "7 - Десеріалізувати;\n" +
                                        "8 - Повернутися назад.");

                switch (ConsoleWorker.ReadItem(true, foregroundColor: ConsoleColor.Cyan))
                {
                    case "1":
                    {
                        ConsoleWorker.Clear();

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var salary = InputDataHandler.InputSalary();
                        var countOfSubordinates = int.Parse(InputDataHandler.InputCountOfSubordinates());

                        var currentManager = new CurrentManager(firstName, lastName, salary, countOfSubordinates);

                        _entityService.Add(currentManager);

                        ConsoleWorker.Clear();

                        break;
                    }
                    case "2":
                    {
                        ConsoleWorker.Clear();

                        ConsoleWorker.WriteItem("Введіть відому інформацію про менеджера, якого потрібно видалити.\n" +
                                                "Інакше нічого не вводьте і видалиться перший в списку менеджер.");

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var salary = InputDataHandler.InputSalary();
                        var countOfSubordinates = InputDataHandler.InputCountOfSubordinates();

                        var options = new SearchOptions(firstName, lastName, salary: salary, countOfSubordinatesntOf: countOfSubordinates);

                        try
                        {
                            var searchResult = _entityService.Find(options);
                            _entityService.Remove(searchResult);
                            ConsoleWorker.WriteItem("Менеджера видалено.", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (ManagerNotFoundException)
                        {
                            ConsoleWorker.WriteItem("Збігів для видалення не знайдено.", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "3":
                    {
                        ConsoleWorker.Clear();

                        try
                        {
                            var managers = _entityService.Persons.GetData();
                            var i = 1;
                            foreach (var person in managers)
                            {
                                ConsoleWorker.WriteItem($"{i}) {person}", foregroundColor: ConsoleColor.Green);
                                i++;
                            }
                        }
                        catch (ManagerNotFoundException)
                        {
                            ConsoleWorker.WriteItem("Список порожній.", foregroundColor: ConsoleColor.Green);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "4":
                    {
                        ConsoleWorker.Clear();

                        ConsoleWorker.WriteItem("Введіть відому інформацію про менеджера, якого потрібно знайти.\n" +
                                                "Інакше нічого не вводьте і виведеться перший в списку менеджер.");

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var salary = InputDataHandler.InputSalary();
                        var countOfSubordinates = InputDataHandler.InputCountOfSubordinates();

                        var options = new SearchOptions(firstName, lastName, salary: salary, countOfSubordinatesntOf: countOfSubordinates);

                        ConsoleWorker.NewLine();
                        try
                        {
                            ConsoleWorker.WriteItem(_entityService.Find(options), foregroundColor: ConsoleColor.Green);
                        }
                        catch (ManagerNotFoundException)
                        {
                            ConsoleWorker.WriteItem("Студента не знайдено.", foregroundColor: ConsoleColor.Green);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "5":
                    {
                        _entityService.Clear();

                        ConsoleWorker.Clear();
                        ConsoleWorker.WriteItem("Список очищено.", foregroundColor: ConsoleColor.DarkCyan);
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "6":
                    {
                        try
                        {
                            ConsoleWorker.Clear();
                            _serializationService.SerializeManager(_entityService);
                            ConsoleWorker.WriteItem("Серіалізація пройшла успісно", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (Exception exception)
                        {
                            ConsoleWorker.WriteItem(exception, foregroundColor: ConsoleColor.DarkRed);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "7":
                    {
                        try
                        {
                            ConsoleWorker.Clear();
                            _serializationService.DeserializeManagers(_entityService);
                            ConsoleWorker.WriteItem("Десеріалізація пройшла успісно", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (Exception exception)
                        {
                            ConsoleWorker.WriteItem(exception, foregroundColor: ConsoleColor.DarkRed);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "8":
                    {
                        flag = false;
                        break;
                    }
                    default:
                    {
                        ConsoleWorker.WriteItem("Дія вибрана невірно!", foregroundColor: ConsoleColor.Red);
                        break;
                    }
                }
            }
        }

        public void McdonaldsWorkerMenu()
        {
            _entityService.Persons = _storage.McdonaldsWorkers;

            ConsoleWorker.Clear();

            var flag = true;
            while (flag)
            {
                ConsoleWorker.WriteItem("Виберіть дію:\n" +
                                        "1 - Додати працівника макдональдсу;\n" +
                                        "2 - Видалити працівника макдональдсу;\n" +
                                        "3 - Показати список працівників макдональдсу;\n" +
                                        "4 - Знайти працівника макдональдсу;\n" +
                                        "5 - Очистити список;\n" +
                                        "6 - Серіалізувати;\n" +
                                        "7 - Десеріалізувати;\n" +
                                        "8 - Повернутися назад.");

                switch (ConsoleWorker.ReadItem(true, foregroundColor: ConsoleColor.Cyan))
                {
                    case "1":
                    {
                        ConsoleWorker.Clear();

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var salary = InputDataHandler.InputSalary();
                        var diploma = InputDataHandler.InputDiploma();

                        var currentMcdonaldsWorker = new CurrentMcdonaldsWorker(firstName, lastName, salary, diploma);

                        _entityService.Add(currentMcdonaldsWorker);

                        ConsoleWorker.Clear();

                        break;
                    }
                    case "2":
                    {
                        ConsoleWorker.Clear();

                        ConsoleWorker.WriteItem("Введіть відому інформацію про працівника МакДональдсу, якого потрібно видалити.\n" +
                                                "Інакше нічого не вводьте і видалиться перший в списку працівник.");

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var salary = InputDataHandler.InputSalary();
                        var diploma = InputDataHandler.InputDiploma();

                        var options = new SearchOptions(firstName, lastName, salary: salary, diploma: diploma);

                        try
                        {
                            var searchResult = _entityService.Find(options);
                            _entityService.Remove(searchResult);
                            ConsoleWorker.WriteItem("Працівника МакДональдсу видалено.", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (McdonaldsWorkerNotFoundException)
                        {
                            ConsoleWorker.WriteItem("Збігів для видалення не знайдено.", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "3":
                    {
                        ConsoleWorker.Clear();

                        try
                        {
                            var mcdonaldsWorkers = _entityService.Persons.GetData();
                            var i = 1;
                            foreach (var person in mcdonaldsWorkers)
                            {
                                ConsoleWorker.WriteItem($"{i}) {person}", foregroundColor: ConsoleColor.Green);
                                i++;
                            }
                        }
                        catch (McdonaldsWorkerNotFoundException)
                        {
                            ConsoleWorker.WriteItem("Список порожній", foregroundColor: ConsoleColor.Green);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "4":
                    {
                        ConsoleWorker.Clear();

                        ConsoleWorker.WriteItem("Введіть відому інформацію про працівника МакДональдсу, якого потрібно знайти.\n" +
                                                "Інакше нічого не вводьте і виведеться перший в списку працівник.");

                        var firstName = InputDataHandler.InputName("ім'я");
                        var lastName = InputDataHandler.InputName("фамілію");
                        var salary = InputDataHandler.InputSalary();
                        var diploma = InputDataHandler.InputDiploma();

                        var options = new SearchOptions(firstName, lastName, salary: salary, diploma: diploma);

                        ConsoleWorker.NewLine();

                        try
                        {
                            ConsoleWorker.WriteItem(_entityService.Find(options), foregroundColor: ConsoleColor.Green);
                        }
                        catch (McdonaldsWorkerNotFoundException)
                        {
                            ConsoleWorker.WriteItem("Працівника не знайдено.", foregroundColor: ConsoleColor.Green);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "5":
                    {
                        _entityService.Clear();

                        ConsoleWorker.Clear();
                        ConsoleWorker.WriteItem("Список очищено.", foregroundColor: ConsoleColor.DarkCyan);
                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "6":
                    {
                        try
                        {
                            ConsoleWorker.Clear();
                            _serializationService.SerializeMcdonaldsWorker(_entityService);
                            ConsoleWorker.WriteItem("Серіалізація пройшла успісно", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (Exception exception)
                        {
                            ConsoleWorker.WriteItem(exception, foregroundColor: ConsoleColor.DarkRed);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "7":
                    {
                        try
                        {
                            ConsoleWorker.Clear();
                            _serializationService.DeserializeMcdonaldsWorkers(_entityService);
                            ConsoleWorker.WriteItem("Десеріалізація пройшла успісно", foregroundColor: ConsoleColor.DarkCyan);
                        }
                        catch (Exception exception)
                        {
                            ConsoleWorker.WriteItem(exception, foregroundColor: ConsoleColor.DarkRed);
                        }

                        ConsoleWorker.NewLine();

                        break;
                    }
                    case "8":
                    {
                        flag = false;
                        break;
                    }
                    default:
                    {
                        ConsoleWorker.WriteItem("Дія вибрана невірно!", foregroundColor: ConsoleColor.Red);
                        break;
                    }
                }
            }
        }
    }
}
