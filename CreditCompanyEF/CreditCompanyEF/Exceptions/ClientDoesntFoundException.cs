using System;
using System.Runtime.Serialization;

namespace CreditCompanyEF.Exceptions
{
    [Serializable]
    internal class ClientDoesntFoundException : ApplicationException
    {
        public ClientDoesntFoundException()
        {
        }

        public ClientDoesntFoundException(string message) : base(message)
        {
        }

        public ClientDoesntFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientDoesntFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}