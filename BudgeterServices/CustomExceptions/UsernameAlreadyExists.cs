using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.CustomExceptions
{
    public class UsernameAlreadyExists : Exception
    {
        public UsernameAlreadyExists()
        {
        }

        public UsernameAlreadyExists(string message) : base(message)
        {
        }

        public UsernameAlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsernameAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
