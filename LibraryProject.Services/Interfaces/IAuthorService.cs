using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Interfaces
{
    public interface IAuthorService
    {
        Author addAuthor(Author author);
        Author deleteAuthor(Guid id);
        Author update(Guid id, Author newAuthor);
        Author getAuthorbyPhonenumber(string phonenumber);
        IQueryable<Author> List(Expression<Func<Author, bool>> filter = null, Expression<Func<Author, int>> sortOrder = null);
    }
}
