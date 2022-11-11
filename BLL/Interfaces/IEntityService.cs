using System.Collections.Generic;

namespace BLL
{
    public interface IEntityService
    {
        IPersons Persons { get; set; }
        void Add(CurrentPerson person);
        CurrentPerson Find(SearchOptions options);
        List<CurrentPerson> FindAll(SearchOptions options);
        void Remove(CurrentPerson person);
        void Clear();
    }
}
