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
        public SerializationType Type { get; private set; }
        public string Connection { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;
        public string Name { get; private set; } = "";

        public void SetSerializationType(int type)
        {
            switch (type)
            {
                case 1:
                {
                    Type = SerializationType.Binary;
                    break;
                }
                case 2:
                {
                    Type = SerializationType.Xml;
                    break;
                }
                case 3:
                {
                    Type = SerializationType.Json;
                    break;
                }
                case 4:
                {
                    Type = SerializationType.Custom; 
                    break;
                }
                default:
                {
                    Type = SerializationType.Binary;
                    break;
                }
            }
        }

        public void SetConnection(string path)
        {
            Connection = path;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SerializeStudents(EntityService students)
        {
            try
            {
                var temp = students.Persons.GetData().Cast<CurrentStudent>().ToList();
                var studentsList = temp.Select(student => EntityCreator.CreateStudent(student.FirstName,
                    student.LastName, student.Course, student.StudentId,
                    student.Gpa, student.Country, student.NumberOfScorebook)).ToList();
                GetEntityContext<List<Student>>(Connection + Name + ".students").SetData(studentsList);
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
                GetEntityContext<List<Manager>>(Connection + Name + ".managers").SetData(managersList);
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
                GetEntityContext<List<McdonaldsWorker>>(Connection + Name + ".mcdonaldsWorkers").SetData(mcdonaldsWorkersList);
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
                var studentsList = GetEntityContext<List<Student>>(Connection + Name + ".students").GetData();
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
                var managersList = GetEntityContext<List<Manager>>(Connection + Name + ".managers").GetData();
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
                    GetEntityContext<List<McdonaldsWorker>>(Connection + Name + ".mcdonaldsWorkers").GetData();
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

            switch (Type)
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