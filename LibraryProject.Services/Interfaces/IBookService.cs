using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> ListAlL();
        void Create(Book newBook);
        void Update(Guid guid,Book newBook); 
        void Delete(Guid guid);

    }
}
