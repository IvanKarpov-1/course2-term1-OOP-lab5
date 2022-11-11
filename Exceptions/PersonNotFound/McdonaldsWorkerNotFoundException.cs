using System;

namespace Exceptions
{
    public class McdonaldsWorkerNotFoundException : PersonNotFoundException
    {
        public McdonaldsWorkerNotFoundException()
        {
        }

        public McdonaldsWorkerNotFoundException(string message) : base(message)
        {
        }

        public McdonaldsWorkerNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}