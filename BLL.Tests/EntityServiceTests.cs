using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    [TestClass]
    public class EntityServiceTests
    {
        private readonly DataStorage _storage = new DataStorage();
        private readonly EntityService _entityService = new EntityService();
        private readonly SerializationService _serializationService = new SerializationService();

        private const string FirstName = "";
        private const string LastName = "";
        private const string Country = "";
        private const string Course = "";
        private const string StudentId = "";
        private const string NumberOfScorebook = "";
        private const double Gpa = 100.00;
        private const string Salary = "";
        private const int CountOfSubordinates = int.MinValue;
        private const bool Diploma = false;

        [TestMethod]
        public void Add_should_add_student_to_students()
        {
            var expected = new CurrentStudent(FirstName, LastName, Course, StudentId, Gpa, Country, NumberOfScorebook);
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            _entityService.Persons = _storage.Students;
            _entityService.Clear();

            _entityService.Add(expected);

            var actual = _entityService.Find(searchOptions);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Add_should_add_manager_to_managers()
        {
            var expected = new CurrentManager(FirstName, LastName, Salary, CountOfSubordinates);
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            _entityService.Persons = _storage.Managers;
            _entityService.Clear();

            _entityService.Add(expected);

            var actual = _entityService.Find(searchOptions);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Add_should_add_mcworker_to_mcworkers()
        {
            var expected = new CurrentMcdonaldsWorker(FirstName, LastName, Course, Diploma);
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName, diploma: Diploma);
            _entityService.Persons = _storage.McdonaldsWorkers;
            _entityService.Clear();

            _entityService.Add(expected);

            var actual = _entityService.Find(searchOptions);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Remove_should_remove_student_to_students()
        {
            var student = new CurrentStudent(FirstName, LastName, Course, StudentId, Gpa, Country, NumberOfScorebook);
            const int expected = 1;
            _entityService.Persons = _storage.Students;
            _entityService.Clear();

            _entityService.Add(student);
            _entityService.Add(student);
            _entityService.Remove(student);

            var actual = _entityService.Persons.GetData().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_should_remove_manager_to_managers()
        {
            var manager = new CurrentManager(FirstName, LastName, Salary, CountOfSubordinates);
            const int expected = 1;
            _entityService.Persons = _storage.Managers;
            _entityService.Clear();
            _entityService.Add(manager);
            _entityService.Add(manager);

            _entityService.Remove(manager);

            var actual = _entityService.Persons.GetData().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_should_remove_mcworker_to_mcworkers()
        {
            var mcdonaldsWorker = new CurrentMcdonaldsWorker(FirstName, LastName, Course, Diploma);
            const int expected = 1;
            _entityService.Persons = _storage.McdonaldsWorkers;
            _entityService.Clear();
            _entityService.Add(mcdonaldsWorker);
            _entityService.Add(mcdonaldsWorker);

            _entityService.Remove(mcdonaldsWorker);

            var actual = _entityService.Persons.GetData().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_should_get_list_of_all_matches_students()
        {
            var student = new CurrentStudent(FirstName, LastName, Course, StudentId, Gpa, Country, NumberOfScorebook);
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            const int expected = 3;
            _entityService.Persons = _storage.Students;
            _entityService.Clear();
            _entityService.Add(student);
            _entityService.Add(student);
            _entityService.Add(student);

            var actual = _entityService.FindAll(searchOptions).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_should_get_list_of_all_matches_managers()
        {
            var manager = new CurrentManager(FirstName, LastName, Salary, CountOfSubordinates);
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            const int expected = 3;
            _entityService.Persons = _storage.Managers;
            _entityService.Clear();
            _entityService.Add(manager);
            _entityService.Add(manager);
            _entityService.Add(manager);

            var actual = _entityService.FindAll(searchOptions).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAll_should_get_list_of_all_matches_mcworkers()
        {
            var mcdonaldsWorker = new CurrentMcdonaldsWorker(FirstName, LastName, Course, Diploma);
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName, diploma: Diploma);
            const int expected = 3;
            _entityService.Persons = _storage.McdonaldsWorkers;
            _entityService.Clear();
            _entityService.Add(mcdonaldsWorker);
            _entityService.Add(mcdonaldsWorker);
            _entityService.Add(mcdonaldsWorker);

            var actual = _entityService.FindAll(searchOptions).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_should_throw_StudentNotFountException()
        {
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            _entityService.Persons = _storage.Students;
            _entityService.Clear();

            Assert.ThrowsException<StudentNotFountException>(() => _entityService.Find(searchOptions));
        }

        [TestMethod]
        public void Find_should_throw_ManagerNotFoundException()
        {
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            _entityService.Persons = _storage.Managers;
            _entityService.Clear();

            Assert.ThrowsException<ManagerNotFoundException>(() => _entityService.Find(searchOptions));
        }

        [TestMethod]
        public void Find_should_throw_McdonaldsWorkerNotFoundException()
        {
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName, diploma: Diploma);
            _entityService.Persons = _storage.McdonaldsWorkers;
            _entityService.Clear();

            Assert.ThrowsException<McdonaldsWorkerNotFoundException>(() => _entityService.Find(searchOptions));
        }

        [TestMethod]
        public void FindAll_should_throw_StudentNotFountException()
        {
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            _entityService.Persons = _storage.Students;
            _entityService.Clear();

            Assert.ThrowsException<StudentNotFountException>(() => _entityService.FindAll(searchOptions));
        }

        [TestMethod]
        public void FindAll_should_throw_ManagerNotFoundException()
        {
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName);
            _entityService.Persons = _storage.Managers;
            _entityService.Clear();

            Assert.ThrowsException<ManagerNotFoundException>(() => _entityService.FindAll(searchOptions));
        }

        [TestMethod]
        public void FindAll_should_throw_McdonaldsWorkerNotFoundException()
        {
            var searchOptions = new SearchOptions(firstName: FirstName, lastName: LastName, diploma: Diploma);
            _entityService.Persons = _storage.McdonaldsWorkers;
            _entityService.Clear();

            Assert.ThrowsException<McdonaldsWorkerNotFoundException>(() => _entityService.FindAll(searchOptions));
        }
    }
}