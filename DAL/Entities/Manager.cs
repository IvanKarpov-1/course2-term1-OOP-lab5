using System;
using System.Runtime.Serialization;

namespace DAL
{
    [Serializable]
    public class Manager : Employee
    {
        public int CountOfSubordinates { get; set; }

        public Manager()
        {
        }

        public Manager(int countOfSubordinates, string salary, string firstName, string lastName) : base(salary,
            firstName, lastName, new Manage())
        {
            CountOfSubordinates = countOfSubordinates;
        }

        protected Manager(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            CountOfSubordinates = info.GetInt32("CountOfSubordinates");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("CountOfSubordinates", CountOfSubordinates);
        }
    }
}