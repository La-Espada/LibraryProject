using LibraryDb.Infrastructure;
using LibraryProject.Backend.Domain.Model;
using LibraryProject.Backend.Exceptions;
using LibraryProject.Backend.Infrastructure;
using LibraryProject.Services.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryContext _libraryContext;

        public AuthorService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public Author addAuthor(Author author)
        {

            try
            {
                bool x = _libraryContext.Authors.Any(e => e.LastName == author.LastName);
                if (!x)
                {
                    _libraryContext.Entry(author).State = EntityState.Added;
                    _libraryContext.SaveChanges();
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                throw new EntryPointNotFoundException("Datensatz existiert schon");
             }
            return author;
        }

        public Author deleteAuthor(Guid id)
        {
            try
            {
                var authors = _libraryContext.Authors.Find(id);
                _libraryContext.Entry(authors).State = EntityState.Deleted;
                return authors;
            }
            catch(SqliteException ex)
            {
                throw new AuthorException("Datensatz wurde nicht gefunden");
            }

            
        }

        public Author getAuthorbyPhonenumber(string phonenumber)
        {
            return _libraryContext.Authors.Where(s => s.Phonenumber == phonenumber).First();
        }

        public IQueryable<Author> List(Expression<Func<Author, bool>> filter = null, Expression<Func<Author, int>> sortOrder = null)
        {
            IQueryable<Author> author = _libraryContext.Authors;

            if(filter is not null)
            {
                author = author.Where(filter);
            }

            if(sortOrder is not null)
            {
                author = author.OrderBy(filter);
            }

            return author;
        }

        public Author update(Guid id, Author newAuthor)
        {
            try
            {
                Author? a = _libraryContext.Authors.Find(id);
                a = newAuthor;
                _libraryContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool x = _libraryContext.Authors.Any(e => e.guid == id);

                if (!x)
                {
                    throw new KeyNotFoundException("Datensatz wurde nicht gefunden");
                }
            }

            return newAuthor;
        }

    }
}
