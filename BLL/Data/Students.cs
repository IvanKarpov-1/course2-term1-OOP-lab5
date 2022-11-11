using System.Collections.Generic;
using System.Linq;
using Exceptions;

namespace BLL
{
    public class Students : IPersons
    {
        private readonly List<CurrentStudent> _students = new List<CurrentStudent>();

        public void Add(CurrentPerson student)
        {
            _students.Add((CurrentStudent)student);
        }

        public CurrentPerson Find(SearchOptions options)
        {
            var result = _students.Find(x => x.FirstName.Contains(options.FirstName) &&
                                           x.LastName.Contains(options.LastName) &&
                                           x.StudentId.Contains(options.StudentId) &&
                                           x.NumberOfScorebook.Contains(options.NumberOfScorebook) &&
                                           x.Course.Contains(options.Course) &&
                                           x.Country.Contains(options.Country));
            if (result == null) throw new StudentNotFountException();
            return result;
        }

        public List<CurrentPerson> FindAll(SearchOptions options)
        {
            var result = _students.FindAll(x => x.FirstName.Contains(options.FirstName) &&
                                          x.LastName.Contains(options.LastName) &&
                                          x.StudentId.Contains(options.StudentId) &&
                                          x.NumberOfScorebook.Contains(options.NumberOfScorebook) &&
                                          x.Course.Contains(options.Course) &&
                                          x.Country.Contains(options.Country)).Cast<CurrentPerson>().ToList();
            if (result.Count == 0) throw new StudentNotFountException();
            return result;
        }


        public void Remove(CurrentPerson student)
        {
            var result = _students.Remove((CurrentStudent)student);
            if (result == false) throw new StudentNotFountException();
        }

        public void Clear()
        {
            _students.Clear();
        }

        public List<CurrentPerson> GetData()
        {
            var result = _students.Cast<CurrentPerson>().ToList();
            if (_students.Count == 0) throw new StudentNotFountException();
            return result;
        }
    }
}
