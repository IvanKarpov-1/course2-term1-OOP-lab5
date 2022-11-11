using System;

namespace Exceptions
{
    public class StudentNotFountException : PersonNotFoundException
    {
        public StudentNotFountException()
        {
        }

        public StudentNotFountException(string message) : base(message)
        {
        }

        public StudentNotFountException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}