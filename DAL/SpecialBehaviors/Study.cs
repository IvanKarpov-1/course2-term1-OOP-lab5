using System;

namespace DAL
{
    [Serializable]
    internal class Study : ISpecialBehavior
    {
        public string Do()
        {
            return "Вчиться...";
        }
    }
}