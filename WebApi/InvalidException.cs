using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message)
        {

        }
    }
}
