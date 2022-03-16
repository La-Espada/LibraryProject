using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Exceptions
{
    public class CustomerException: Exception
    {
        public CustomerException()
           : base()
        { }

        public CustomerException(string message)
            : base(message)
        { }

        public CustomerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
