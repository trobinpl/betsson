using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace escapemines.Game
{
    internal class IncorrectAngleException : ApplicationException
    {
        public IncorrectAngleException()
        {
        }

        public IncorrectAngleException(string message) : base(message)
        {
        }

        public IncorrectAngleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectAngleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
