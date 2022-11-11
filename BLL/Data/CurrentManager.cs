namespace BLL
{
    public class CurrentManager : CurrentEmployee
    {
        public int CountOfSubordinates { get; }


        public CurrentManager(string firstName, string lastName, string salary, int countOfSubordinates) : base(firstName, lastName, salary)
        {
            CountOfSubordinates = countOfSubordinates;
        }

        public override string ToString()
        {
            return $"Менеджер {FirstName} {LastName}, зарплата - {Salary}, кількість підлеглих - {CountOfSubordinates}";
        }
    }
}
