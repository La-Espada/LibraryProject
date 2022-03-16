using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Interfaces
{
    public interface ILibraryService
    {
        List<Library> ListAll();
        void Create(Library newLibrary);
        void Update(Guid guid,Library newLibrary);
        void Delete(Guid guid);
    }
}
