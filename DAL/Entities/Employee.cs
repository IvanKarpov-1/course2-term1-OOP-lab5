using System;
using System.Runtime.Serialization;

namespace DAL
{
    [Serializable]
    public abstract class Employee : Person
    {
        public string Salary { get; set; }

        protected Employee()
        {
        }

        protected Employee(string salary, string firstName, string lastName, ISpecialBehavior specialBehavior) : base(
            firstName, lastName, specialBehavior)
        {
            Salary = salary;
        }

        protected Employee(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Salary = info.GetString("Salary");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Salary", Salary);
        }
    }
}