using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Shared.Exceptions
{
    public class ClientOrderAuthorizationException : Exception
    {
        public ClientOrderAuthorizationException()
        {
        }

        public ClientOrderAuthorizationException(string message)
            : base(message)
        {
        }

        public ClientOrderAuthorizationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
