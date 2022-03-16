using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Exceptions
{
    public class LibraryException : Exception
    {
        public LibraryException() 
        : base()
        { }

        public LibraryException(string message) 
        :base(message)
        { }

        public LibraryException(string message,Exception ex)
            :base(message,ex)
        { }
    }
}
