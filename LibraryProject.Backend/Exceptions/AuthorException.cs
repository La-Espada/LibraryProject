using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Exceptions
{
    public class AuthorException : Exception
    {
        public AuthorException()
            : base()
        { }

        public AuthorException(string message)
            : base(message)
        { }

        public AuthorException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
