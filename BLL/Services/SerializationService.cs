using BinaryProvider;
using CustomProvider;
using DAL;
using JsonProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using XMLDataProvider;

namespace BLL
{
    public enum SerializationType
    {
        Binary,
        Xml,
        Json,
        Custom
    }

    public class SerializationService
    {
        private SerializationType _type;
        private string _connection = AppDomain.CurrentDomain.BaseDirectory;
        private string _name = "";

        public void SetSerializationType(int type)
        {
            switch (type)
            {
                case 1:
                {
                    _type = SerializationType.Binary;
                    break;
                }
                case 2:
                {
                    _type = SerializationType.Xml;
                    break;
                }
                case 3:
                {
                    _type = SerializationType.Json;
                    break;
                }
                case 4:
                {
                    _type = SerializationType.Custom; 
                    break;
                }
                default:
                {
                    return;
                }
            }
        }

        public void SetConnection(string path)
        {
            _connection = path;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SerializeStudents(EntityService students)
        {
            try
            {
                var temp = students.Persons.GetData().Cast<CurrentStudent>().ToList();
                var studentsList = temp.Select(student => EntityCreator.CreateStudent(student.FirstName,
                    student.LastName, student.Course, student.StudentId,
                    student.Gpa, student.Country, student.NumberOfScorebook)).ToList();
                GetEntityContext<List<Student>>(_connection + _name + ".students").SetData(studentsList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SerializeManager(EntityService managers)
        {
            try
            {
                var temp = managers.Persons.GetData().Cast<CurrentManager>().ToList();
                var managersList = temp.Select(manager => EntityCreator.CreateManager(manager.FirstName,
                    manager.LastName, manager.CountOfSubordinates, manager.Salary)).ToList();
                GetEntityContext<List<Manager>>(_connection + _name + ".managers").SetData(managersList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SerializeMcdonaldsWorker(EntityService mcdonaldsWorkers)
        {
            try
            {
                var temp = mcdonaldsWorkers.Persons.GetData().Cast<CurrentMcdonaldsWorker>().ToList();
                var mcdonaldsWorkersList = temp.Select(mcdonaldsWorker =>
                    EntityCreator.CreateMcdonaldsWorker(
                        mcdonaldsWorker.FirstName, mcdonaldsWorker.LastName, mcdonaldsWorker.Diploma,
                        mcdonaldsWorker.Salary)).ToList();
                GetEntityContext<List<McdonaldsWorker>>(_connection + _name + ".mcdonaldsWorkers").SetData(mcdonaldsWorkersList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeserializeStudents(EntityService students)
        {
            try
            {
                var studentsList = GetEntityContext<List<Student>>(_connection + _name + ".students").GetData();
                students.Persons.Clear();
                foreach (var student in studentsList)
                {
                    students.Add(new CurrentStudent(student.FirstName, student.LastName, student.Course, student.StudentId,
                        student.Gpa, student.Country, student.NumberOfScorebook));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeserializeManagers(EntityService managers)
        {
            try
            {
                var managersList = GetEntityContext<List<Manager>>(_connection + _name + ".managers").GetData();
                managers.Persons.Clear();
                foreach (var manager in managersList)
                {
                    managers.Add(new CurrentManager(manager.FirstName, manager.LastName, manager.Salary, manager.CountOfSubordinates));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeserializeMcdonaldsWorkers(EntityService mcdonaldsWorkers)
        {
            try
            {
                var mcdonaldsWorkersList =
                    GetEntityContext<List<McdonaldsWorker>>(_connection + _name + ".mcdonaldsWorkers").GetData();
                mcdonaldsWorkers.Persons.Clear();
                foreach (var mcdonaldsWorker in mcdonaldsWorkersList)
                {
                    mcdonaldsWorkers.Add(new CurrentMcdonaldsWorker(mcdonaldsWorker.FirstName, mcdonaldsWorker.LastName,
                        mcdonaldsWorker.Salary, mcdonaldsWorker.Diploma));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private EntityContext<T> GetEntityContext<T>(string connection)
        {
            var entityContext = new EntityContext<T>(connection);

            switch (_type)
            {
                case SerializationType.Binary:
                {
                    entityContext.DataProvider = new BinaryDataProvider<T>();
                    break;
                }
                case SerializationType.Xml:
                {
                    entityContext.DataProvider = new XmlDataProvider<T>();
                    break;
                }
                case SerializationType.Json:
                {
                    entityContext.DataProvider = new JsonDataProvider<T>();
                    break;
                }
                case SerializationType.Custom:
                {
                    entityContext.DataProvider = new CustomDataProvider<T>();
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return entityContext;
        }
    }
}