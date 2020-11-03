using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace escapemines.Game
{
    public class IncorrectDirectionException : ApplicationException
    {
        public IncorrectDirectionException()
        {
        }

        public IncorrectDirectionException(string message) : base(message)
        {
        }

        public IncorrectDirectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectDirectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
