using System.Runtime.Serialization;

namespace PPOIS3.Exceptions
{
    public class NotEnoughItemsException : Exception
    {
        public NotEnoughItemsException()
        {
        }

        public NotEnoughItemsException(string? message) : base(message)
        {
        }

        public NotEnoughItemsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotEnoughItemsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
