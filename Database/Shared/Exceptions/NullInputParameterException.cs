using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database.Shared.Exceptions
{
    public class NullInputParameterException : Exception
    {
        public NullInputParameterException()
        {
        }

        public NullInputParameterException(string message)
            : base(message)
        {
        }

        public NullInputParameterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
