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
    public class BookService : IBookService
    {
        private readonly LibraryContext _libraryContext;

        public BookService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;  
        }
        List<Book> IBookService.ListAlL()
        {
           return _libraryContext.Books.ToList();
        }
        void IBookService.Create(Book newBook)
        {
            try
            {
                bool x = _libraryContext.Books.Any(e => e.BookName == newBook.BookName);
                if (!x)
                {
                    _libraryContext.Entry(newBook).State = EntityState.Added;
                    _libraryContext.SaveChanges();

                }
            }catch(EntryPointNotFoundException ex)
            {
                throw new EntryPointNotFoundException("Data already exists");
            }
        }

        void IBookService.Delete(Guid guid)
        {
            try
            {
                var book = _libraryContext.Books.Find(guid);
                _libraryContext.Remove(book);
            }catch(EntryPointNotFoundException ex)
            {
                throw new BookException("Data does not exist",ex);
            }
        }

        void IBookService.Update(Guid guid, Book newBook)
        {
            try
            {
                Book? a = _libraryContext.Books.Find(guid);
                a = newBook;
                _libraryContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                bool x = _libraryContext.Books.Any(e => e.guid == guid);

                if (!x)
                {
                    throw new KeyNotFoundException("Data can not be found");
                }
                
            }
        }
    }
}
