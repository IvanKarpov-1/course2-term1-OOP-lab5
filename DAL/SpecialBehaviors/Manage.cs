using System;

namespace DAL
{
    [Serializable]
    internal class Manage : ISpecialBehavior
    {
        public string Do()
        {
            return "Керує...";
        }
    }
}