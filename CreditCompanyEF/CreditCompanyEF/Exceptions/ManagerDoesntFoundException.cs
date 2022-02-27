using System;
using System.Runtime.Serialization;

namespace CreditCompanyEF.Exceptions
{
    [Serializable]
    internal class ManagerDoesntFoundException : ApplicationException
    {
        public ManagerDoesntFoundException()
        {
        }

        public ManagerDoesntFoundException(string message) : base(message)
        {
        }

        public ManagerDoesntFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ManagerDoesntFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}