using System;
using System.Runtime.Serialization;

namespace CreditCompanyEF.Exceptions
{
    [Serializable]
    internal class ManagerDoesNotFound : ApplicationException
    {
        public ManagerDoesNotFound()
        {
        }

        public ManagerDoesNotFound(string message) : base(message)
        {
        }

        public ManagerDoesNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ManagerDoesNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}