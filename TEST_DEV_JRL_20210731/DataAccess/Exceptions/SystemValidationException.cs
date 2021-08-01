using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_DEV_JRL_20210731.DataAccess.Exceptions
{
    public class SystemValidationException : Exception
    {
        public SystemValidationException(string message) : base(message)
        {

        }
    }
}
