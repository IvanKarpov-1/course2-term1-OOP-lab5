namespace BLL
{
    public class SearchOptions
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string StudentId { get; }
        public string NumberOfScorebook { get; }
        public string Course { get; }
        public string Country { get; }
        public string Salary { get; }
        public string CountOfSubordinatesntOf { get; }
        public bool Diploma { get; }

        public SearchOptions(string firstName = "", string lastName = "", string studentId = "",
            string numberOfScorebook = "", string course = "", string country = "", string salary = "", string countOfSubordinatesntOf = "", bool diploma = true)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentId = studentId;
            NumberOfScorebook = numberOfScorebook;
            Course = course;
            Country = country;
            Salary = salary;
            CountOfSubordinatesntOf = countOfSubordinatesntOf;
            Diploma = diploma;
        }
    }
}