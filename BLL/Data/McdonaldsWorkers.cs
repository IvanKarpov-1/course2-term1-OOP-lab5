using Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class McdonaldsWorkers : IPersons
    {
        private readonly List<CurrentMcdonaldsWorker> _mcdonaldsWorkers = new List<CurrentMcdonaldsWorker>();

        public void Add(CurrentPerson mcdonaldsWorker)
        {
            _mcdonaldsWorkers.Add((CurrentMcdonaldsWorker)mcdonaldsWorker);
        }

        public CurrentPerson Find(SearchOptions options)
        {
            var result = _mcdonaldsWorkers.Find(x => x.FirstName.Contains(options.FirstName) &&
                                               x.LastName.Contains(options.LastName) &&
                                               x.Salary.Contains(options.Salary) &&
                                               x.Diploma.ToString().Contains(options.Diploma.ToString()));
            if (result == null) throw new McdonaldsWorkerNotFoundException();
            return result;
        }

        public List<CurrentPerson> FindAll(SearchOptions options)
        {
            var result = _mcdonaldsWorkers.FindAll(x => x.FirstName.Contains(options.FirstName) &&
                                                  x.LastName.Contains(options.LastName) &&
                                                  x.Salary.Contains(options.Salary) &&
                                                  x.Diploma.ToString().Contains(options.Diploma.ToString()))
                .Cast<CurrentPerson>().ToList();
            if (result.Count == 0) throw new McdonaldsWorkerNotFoundException();
            return result;
        }

        public void Remove(CurrentPerson mcdonaldsWorker)
        {
            var result = _mcdonaldsWorkers.Remove((CurrentMcdonaldsWorker)mcdonaldsWorker);
            if (result == false) throw new McdonaldsWorkerNotFoundException();
        }

        public void Clear()
        {
            _mcdonaldsWorkers.Clear();
        }

        public List<CurrentPerson> GetData()
        {
            var result = _mcdonaldsWorkers.Cast<CurrentPerson>().ToList();
            if (_mcdonaldsWorkers.Count == 0) throw new McdonaldsWorkerNotFoundException();
            return result;
        }
    }
}