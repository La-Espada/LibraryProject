using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Exceptions
{
    public class InventoryException : Exception
    {
        public InventoryException()
            :base()
        { }

        public InventoryException(string message)
            :base(message)
        { }
        public InventoryException(string message,Exception innerException)
        :base(message, innerException)
        { }
    }
}
