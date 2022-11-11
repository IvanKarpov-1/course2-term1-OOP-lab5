namespace DAL
{
    public static class EntityCreator
    {
        public static Student CreateStudent(string firstName, string lastName, string course, 
            string studentId, double gpa, string country, string numberOfScorebook)
        {
            return new Student(course, studentId, gpa, country, numberOfScorebook, firstName, lastName);
        }

        public static Manager CreateManager(string firstName, string lastName, int countsOfSubordinates, string salary)
        {
            return new Manager(countsOfSubordinates, salary, firstName, lastName);
        }

        public static McdonaldsWorker CreateMcdonaldsWorker(string firstName, string lastName, bool diploma, string salary)
        {
            return new McdonaldsWorker(diploma, salary, firstName, lastName);
        }
    }
}