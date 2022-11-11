namespace BLL
{
    public class CurrentStudent : CurrentPerson
    {
        public string Course { get; }
        public string StudentId { get; }
        public double Gpa { get; }
        public string Country { get; }
        public string NumberOfScorebook { get; }

        public CurrentStudent(string firstName, string lastName, string course, string studentId, double gpa, string country, string numberOfScorebook) : base(lastName, firstName)
        {
            Course = course;
            StudentId = studentId;
            Gpa = gpa;
            Country = country;
            NumberOfScorebook = numberOfScorebook;
        }

        public override string ToString()
        {
            return $"Студент - {FirstName} {LastName}, курс - {Course}, ID - {StudentId}, номер залікової книги - {NumberOfScorebook}, середній бал - {Gpa}, країна проживання - {Country}";
        }
    }
}
