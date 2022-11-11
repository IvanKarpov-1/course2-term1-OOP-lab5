using System;

namespace DAL
{
    [Serializable]
    internal class TakeOrders : ISpecialBehavior
    {
        public string Do()
        {
            return "Приймає замовлення...";
        }
    }
}