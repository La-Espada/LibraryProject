using LibraryProject.Backend.Domain.Model;
using LibraryProject.Backend.Exceptions;
using LibraryProject.Backend.Infrastructure;
using LibraryProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryContext _libraryContext;

        public LibraryService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public List<Library> ListAll()
        {
          return _libraryContext.Librarys.ToList();
        }

        public void Create(Library newLibrary)
        {
            try
            {
                bool x = _libraryContext.Librarys.Any(e => e.Name == newLibrary.Name);
                if (!x)
                {
                    _libraryContext.Entry(newLibrary).State = EntityState.Added;
                    _libraryContext.SaveChanges();
                }
            }catch(EntryPointNotFoundException ex)
            {
                throw new EntryPointNotFoundException("Data already exists");
            }
        }
        public void Delete(Guid guid)
        {
            try
            {
                var library = _libraryContext.Librarys.Find(guid);
                if (library != null)
                { 
                    _libraryContext.Remove(library);
                }
            }catch(EntryPointNotFoundException ex)
            {
                throw new LibraryException("Data does not exist", ex);
            }
        }

        public void Update(Guid guid, Library newLibrary)
        {
            try
            {
                Library? a = _libraryContext.Librarys.Find(guid);
                a = newLibrary;
                _libraryContext.SaveChanges();

            }catch(DbUpdateConcurrencyException ex)
            {
                bool x = _libraryContext.Librarys.Any(e => e.guid == guid);

                if (!x)
                {
                    throw new KeyNotFoundException("Data can not be found");
                }
            }
        }

      

    }
}
