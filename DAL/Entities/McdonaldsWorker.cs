using System;
using System.Runtime.Serialization;

namespace DAL
{
    [Serializable]
    public class McdonaldsWorker : Employee
    {
        public bool Diploma { get; set; }

        public McdonaldsWorker()
        {
        }

        public McdonaldsWorker(bool diploma, string salary, string firstName, string lastName) : base(salary, firstName,
            lastName, new TakeOrders())
        {
            Diploma = diploma;
        }

        protected McdonaldsWorker(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Diploma = info.GetBoolean("Diploma");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Diploma", Diploma);
        }
    }
}