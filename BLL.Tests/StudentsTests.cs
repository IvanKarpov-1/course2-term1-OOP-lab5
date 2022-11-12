using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    [TestClass]
    public class StudentsTests
    {
        private readonly Students _students = new Students();

        [TestMethod]
        public void Remove_should_throw_StudentNotFountException()
        {
            var student = new CurrentStudent("", "", "", "", 0, "", "");

            Assert.ThrowsException<StudentNotFountException>(() => _students.Remove(student));
        }

        [TestMethod]
        public void GetData_should_throw_StudentNotFountException()
        {
            Assert.ThrowsException<StudentNotFountException>(() => _students.GetData());
        }
    }
}