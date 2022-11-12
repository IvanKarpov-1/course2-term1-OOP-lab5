using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    [TestClass]
    public class SerializationServiceTests
    {
        private readonly SerializationService _serializationService = new SerializationService();
        private readonly EntityService _entityService = new EntityService();
        private readonly DataStorage _storage = new DataStorage();
        private const int TypeIndex = 1;
        private const string Connection = "DB";
        private const string Name = "Students";

        [TestMethod]
        public void SerializeStudents_should_throw_Exception()
        {
            Assert.ThrowsException<Exception>(() => _serializationService.SerializeStudents(_entityService));
        }

        [TestMethod]
        public void SerializeManager_should_throw_Exception()
        {
            Assert.ThrowsException<Exception>(() => _serializationService.SerializeManager(_entityService));
        }

        [TestMethod]
        public void SerializeMcdonaldsWorker_should_throw_Exception()
        {
            Assert.ThrowsException<Exception>(() => _serializationService.SerializeMcdonaldsWorker(_entityService));
        }

        [TestMethod]
        public void DeserializeStudents_should_throw_Exception()
        {
            Assert.ThrowsException<Exception>(() => _serializationService.DeserializeStudents(_entityService));
        }

        [TestMethod]
        public void DeserializeManagers_should_throw_Exception()
        {
            Assert.ThrowsException<Exception>(() => _serializationService.DeserializeManagers(_entityService));
        }

        [TestMethod]
        public void DeserializeMcdonaldsWorkers_should_throw_Exception()
        {
            Assert.ThrowsException<Exception>(() => _serializationService.DeserializeMcdonaldsWorkers(_entityService));
        }

        [TestMethod]
        public void SetSerializationType_should_set_serialization_first_type()
        {
            const SerializationType expected = SerializationType.Binary;

            _serializationService.SetSerializationType(1);

            var actual = _serializationService.Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetSerializationType_should_set_serialization_second_type()
        {
            const SerializationType expected = SerializationType.Xml;

            _serializationService.SetSerializationType(2);

            var actual = _serializationService.Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetSerializationType_should_set_serialization_third_type()
        {
            const SerializationType expected = SerializationType.Json;

            _serializationService.SetSerializationType(3);

            var actual = _serializationService.Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetSerializationType_should_set_serialization_fourth_type()
        {
            const SerializationType expected = SerializationType.Custom;

            _serializationService.SetSerializationType(4);

            var actual = _serializationService.Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetSerializationType_should_set_serialization_default_type()
        {
            const SerializationType expected = SerializationType.Binary;

            _serializationService.SetSerializationType(0);

            var actual = _serializationService.Type;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetConnection_should_set_connection()
        {
            const string expected = "DB";

            _serializationService.SetConnection(Connection);

            var actual = _serializationService.Connection;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetName_should_set_name()
        {
            const string expected = "Students";

            _serializationService.SetName(Name);

            var actual = _serializationService.Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerializeStudents_should_serialize_students()
        {
            var student = new CurrentStudent("", "", "", "", 0, "", "");
            const int expected = 1;
            _entityService.Persons = _storage.Students;
            _entityService.Clear();
            _entityService.Add(student);
            _serializationService.SetSerializationType(TypeIndex);
            _serializationService.SetConnection(Connection);
            _serializationService.SetName(Name);

            _serializationService.SerializeStudents(_entityService);
            _entityService.Clear();

            _serializationService.DeserializeStudents(_entityService);
            var actual = _entityService.Persons.GetData().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerializeManager_should_serialize_managerss()
        {
            var manager = new CurrentManager("", "", "", 0);
            const int expected = 1;
            _entityService.Persons = _storage.Managers;
            _entityService.Clear();
            _entityService.Add(manager);
            _serializationService.SetSerializationType(TypeIndex);
            _serializationService.SetConnection(Connection);
            _serializationService.SetName(Name);

            _serializationService.SerializeManager(_entityService);
            _entityService.Clear();

            _serializationService.DeserializeManagers(_entityService);
            var actual = _entityService.Persons.GetData().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SerializeMcdonaldsWorker_should_serialize_mcworkerss()
        {
            var mcdonaldsWorker = new CurrentMcdonaldsWorker("", "", "", true);
            const int expected = 1;
            _entityService.Persons = _storage.McdonaldsWorkers;
            _entityService.Clear();
            _entityService.Add(mcdonaldsWorker);
            _serializationService.SetSerializationType(TypeIndex);
            _serializationService.SetConnection(Connection);
            _serializationService.SetName(Name);

            _serializationService.SerializeMcdonaldsWorker(_entityService);
            _entityService.Clear();

            _serializationService.DeserializeMcdonaldsWorkers(_entityService);
            var actual = _entityService.Persons.GetData().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}