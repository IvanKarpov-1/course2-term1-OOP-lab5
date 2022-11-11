namespace BLL
{
    public class CurrentEmployee : CurrentPerson
    {
        public string Salary { get; protected set; }

        public CurrentEmployee(string firstName, string lastName, string salary) : base(lastName, firstName)
        {
            Salary = salary;
        }
    }
}
