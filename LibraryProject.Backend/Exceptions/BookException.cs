using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Exceptions
{
    public class BookException : Exception
    {
        public BookException()
            :base()
        { }

        public BookException(string message)
            :base(message)
        { }

        public BookException(string message,Exception innerException)
            :base(message, innerException)
        { }
    }
}
