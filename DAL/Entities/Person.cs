using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DAL
{
    [Serializable]
    public abstract class Person : ISerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NonSerialized][XmlIgnore]
        public ISpecialBehavior[] SpecialBehaviors = { new PlayChess() };

        protected Person()
        {
        }

        protected Person(string firstName, string lastName, ISpecialBehavior specialBehavior)
        {
            FirstName = firstName;
            LastName = lastName;
            SpecialBehaviors = SpecialBehaviors.Append(specialBehavior).ToArray();
        }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            LastName = info.GetString("LastName");
            FirstName = info.GetString("FirstName");
            SpecialBehaviors = (ISpecialBehavior[])info.GetValue("SpecialBehaviors", typeof(ISpecialBehavior[]));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LastName", LastName);
            info.AddValue("FirstName", FirstName);
            info.AddValue("SpecialBehaviors", SpecialBehaviors);
        }
    }
}