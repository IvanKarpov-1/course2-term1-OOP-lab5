using Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class Managers : IPersons
    {
        private readonly List<CurrentManager> _managers = new List<CurrentManager>();

        public void Add(CurrentPerson manager)
        {
            _managers.Add((CurrentManager)manager);
        }

        public CurrentPerson Find(SearchOptions options)
        {
            var result = _managers.Find(x => x.FirstName.Contains(options.FirstName) &&
                                       x.LastName.Contains(options.LastName) &&
                                       x.Salary.Contains(options.Salary) &&
                                       x.CountOfSubordinates.ToString().Contains(options.CountOfSubordinatesntOf));
            if (result == null) throw new ManagerNotFoundException();
            return result;
        }

        public List<CurrentPerson> FindAll(SearchOptions options)
        {
            var result = _managers.FindAll(x => x.FirstName.Contains(options.FirstName) &&
                                          x.LastName.Contains(options.LastName) &&
                                          x.Salary.Contains(options.Salary) &&
                                          x.CountOfSubordinates.ToString().Contains(options.CountOfSubordinatesntOf))
                .Cast<CurrentPerson>().ToList();
            if (result.Count == 0) throw new ManagerNotFoundException();
            return result;
        }

        public void Remove(CurrentPerson manager)
        {
            var result = _managers.Remove((CurrentManager)manager);
            if (result == false) throw new ManagerNotFoundException();
        }

        public void Clear()
        {
            _managers.Clear();
        }

        public List<CurrentPerson> GetData()
        {
            var result = _managers.Cast<CurrentPerson>().ToList();
            if (_managers.Count == 0) throw new ManagerNotFoundException();
            return result;
        }
    }
}