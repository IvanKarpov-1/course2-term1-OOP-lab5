namespace BLL
{
    public class CurrentPerson
    {
        public string LastName { get; protected set; }
        public string FirstName { get; protected set; }

        public CurrentPerson(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }
    }
}
