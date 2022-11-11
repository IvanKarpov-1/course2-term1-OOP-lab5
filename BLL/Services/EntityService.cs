using System.Collections.Generic;

namespace BLL
{
    public class EntityService : IEntityService
    {
        public IPersons Persons { get; set; }

        public void Add(CurrentPerson person)
        {
            Persons.Add(person);
        }

        public CurrentPerson Find(SearchOptions options)
        {
            return Persons.Find(options);
        }

        public List<CurrentPerson> FindAll(SearchOptions options)
        {
            return Persons.FindAll(options);
        }

        public void Remove(CurrentPerson person)
        {
            Persons.Remove(person);
        }

        public void Clear()
        {
            Persons.Clear();
        }
    }
}
