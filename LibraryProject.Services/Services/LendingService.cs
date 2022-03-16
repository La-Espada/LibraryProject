using LibraryProject.Backend.Domain.Model;
using LibraryProject.Backend.Infrastructure;
using LibraryProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Services
{
    public class LendingService : ILendingService
    {

        private readonly LibraryContext _libraryContext;
        public LendingService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext; 
        }

        public IQueryable<Lending> ListAll(Expression<Func<Lending, bool>> filter = null, Expression<Func<Lending, int>> sortOrder = null)
        {
          IQueryable<Lending> lending = _libraryContext.Lendings;
            if(filter != null)
            {
                lending = lending.Where(filter);
            }
            if(sortOrder != null)
            {
                lending = lending.OrderBy(sortOrder);
            }
            return lending;
        }
        public Lending Create(Lending lending)
        {
            try
            {
                _libraryContext.Entry(lending).State = EntityState.Added;
                _libraryContext.SaveChanges();
            }
            catch(EntryPointNotFoundException ex)
            {
                throw new EntryPointNotFoundException("Data already exists");
            }
            return lending;
        }

        public Lending Delete(Guid guid)
        {
            try
            {
                var lending = _libraryContext.Lendings.Find(guid);
                _libraryContext.Entry(lending).State = EntityState.Added;
                return lending;
            }catch(EntryPointNotFoundException ex)
            {
                throw new EntryPointNotFoundException("Data does not exist");
            }
        }

        public Lending Update(Guid guid, Lending newLending)
        {
            try
            {
                Lending? lending = _libraryContext.Lendings.Find(guid);
                lending = newLending;
                _libraryContext.SaveChanges();

            }catch(DbUpdateConcurrencyException ex)
            {
                bool x = _libraryContext.Lendings.Any(e => e.guid == guid);

                if (!x)
                {
                    throw new KeyNotFoundException("Data can not be found");
                }
            }
            return newLending;
        }
    }
}
