namespace Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class AlreadyExistsException : ArgumentException
    {
        public AlreadyExistsException()
            : this("Entity already exists.")
        {

        }
        public AlreadyExistsException(string message)
            : base(message)
        {

        }
        public AlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        public AlreadyExistsException(string message, string paramName, Exception innerException)
            : base(message, paramName, innerException)
        {

        }
        public AlreadyExistsException(string message, string paramName)
            : base(message, paramName)
        {

        }
        protected AlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

    }
}
