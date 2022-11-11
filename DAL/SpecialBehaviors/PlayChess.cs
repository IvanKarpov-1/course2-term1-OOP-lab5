using System;

namespace DAL
{
    [Serializable]
    internal class PlayChess : ISpecialBehavior
    {
        public string Do()
        {
            return "Грає в шахи...";
        }
    }
}