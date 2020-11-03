using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace escapemines.Game
{
    public class IncorrectCoordinateFormatException : ApplicationException
    {
        public IncorrectCoordinateFormatException()
        {
        }

        public IncorrectCoordinateFormatException(string message) : base(message)
        {
        }

        public IncorrectCoordinateFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectCoordinateFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
