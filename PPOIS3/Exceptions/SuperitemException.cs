using System.Runtime.Serialization;

namespace PPOIS3.Exceptions
{
    public class SuperitemException : Exception
    {
        public SuperitemException()
        {
        }

        public SuperitemException(string? message) : base(message)
        {
        }

        public SuperitemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SuperitemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
