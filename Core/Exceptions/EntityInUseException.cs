using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class EntityInUseException : ArgumentException
    {
        public EntityInUseException()
            : this("This entity is being used.")
        {

        }
        public EntityInUseException(string message)
            : base(message)
        {

        }
        public EntityInUseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        public EntityInUseException(string message, string paramName, Exception innerException)
            : base(message, paramName, innerException)
        {

        }
        public EntityInUseException(string message, string paramName)
            : base(message, paramName)
        {

        }
        protected EntityInUseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
