using System;
using System.Runtime.Serialization;

namespace DAL
{
    [Serializable]
    public class Student : Person
    {
        public string Course { get; set; }
        public string StudentId { get; set; }
        public double Gpa { get; set; }
        public string Country { get; set; }
        public string NumberOfScorebook { get; set; }

        public Student()
        {
        }

        public Student(string course, string studentId, double gpa, string country, string numberOfScorebook,
            string firstName, string lastName) : base(firstName, lastName, new Study())
        {
            Course = course;
            StudentId = studentId;
            Gpa = gpa;
            Country = country;
            NumberOfScorebook = numberOfScorebook;
        }

        protected Student(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Course = info.GetString("Course");
            StudentId = info.GetString("StudentId");
            Gpa = info.GetDouble("Gpa");
            Country = info.GetString("Country");
            NumberOfScorebook = info.GetString("NumberOfScorebook");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Course", Course);
            info.AddValue("StudentId", StudentId);
            info.AddValue("Gpa", Gpa);
            info.AddValue("Country", Country);
            info.AddValue("NumberOfScorebook", NumberOfScorebook);
        }
    }
}