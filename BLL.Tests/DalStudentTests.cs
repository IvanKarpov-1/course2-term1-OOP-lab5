using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    [TestClass]
    public class DalStudentTests
    {
        [TestMethod]
        public void SpecialBehaviour_test_special_behaviour_play_chess()
        {
            var student = new Student();
            const string expected = "Грає в шахи...";

            var actual = student.SpecialBehaviors[0].Do();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SpecialBehaviour_test_special_behaviour_study()
        {
            var student = new Student();
            const string expected = "Вчиться...";

            var actual = student.SpecialBehaviors[1].Do();

            Assert.AreEqual(expected, actual);
        }
    }
}