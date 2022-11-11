namespace BLL
{
    public class CurrentMcdonaldsWorker : CurrentEmployee
    {
        public bool Diploma { get; }

        public CurrentMcdonaldsWorker(string firstName, string lastName, string salary, bool diploma) : base(firstName, lastName, salary)
        {
            Diploma = diploma;
        }

        public override string ToString()
        {
            return $"Працівник МакДональдсу {FirstName} {LastName}, зарплата - {Salary}, диплом - " + (Diploma ? "є" : "немає");
        }
    }
}
