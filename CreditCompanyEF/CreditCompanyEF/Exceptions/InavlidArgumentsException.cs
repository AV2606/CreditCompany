using System;
using System.Runtime.Serialization;

namespace CreditCompanyEF
{
    [Serializable]
    internal class InavlidArgumentsException : Exception
    {
        public InavlidArgumentsException()
        {
        }

        public InavlidArgumentsException(string message) : base(message)
        {
        }

        public InavlidArgumentsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InavlidArgumentsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}