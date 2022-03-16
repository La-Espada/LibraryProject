using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Interfaces
{
    public interface ILendingService
    {
        IQueryable<Lending> ListAll(Expression<Func<Lending, bool>> filter = null, Expression<Func<Lending, int>> sortOrder = null);
        Lending Create(Lending lending);
        Lending Delete(Guid guid);
        Lending Update(Guid guid,Lending newLending);
    }
}
