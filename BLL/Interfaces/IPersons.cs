using System.Collections.Generic;

namespace BLL
{
    public interface IPersons
    {
        void Add(CurrentPerson person);
        CurrentPerson Find(SearchOptions options);
        List<CurrentPerson> FindAll(SearchOptions options);
        void Remove(CurrentPerson person);
        void Clear();
        List<CurrentPerson> GetData();
    }
}