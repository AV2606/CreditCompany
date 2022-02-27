using System;
using System.Runtime.Serialization;

namespace CreditCompany
{
    [Serializable]
    internal class TooMuchControlsException : Exception
    {
        public TooMuchControlsException()
        {
        }

        public TooMuchControlsException(string message) : base(message)
        {
        }

        public TooMuchControlsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooMuchControlsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}