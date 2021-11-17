using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.CustomExceptions
{
    public class InvalidSignInException : Exception
    {
        public InvalidSignInException()
        {
        }

        public InvalidSignInException(string message) : base(message)
        {
        }

        public InvalidSignInException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSignInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
