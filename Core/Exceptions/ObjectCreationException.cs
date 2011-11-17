namespace Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ObjectCreationException : NullReferenceException
    {
        public ObjectCreationException()
            : this("Could not find object in container.  Please check and make sure the application is configured to properly instantiate this object type.")
        {

        }
        public ObjectCreationException(string message)
            : base(message)
        {

        }

        public ObjectCreationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected ObjectCreationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
