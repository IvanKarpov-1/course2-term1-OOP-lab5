using System;

namespace Exceptions
{
    public class ManagerNotFoundException : PersonNotFoundException
    {
        public ManagerNotFoundException()
        {
        }

        public ManagerNotFoundException(string message) : base(message)
        {
        }

        public ManagerNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}