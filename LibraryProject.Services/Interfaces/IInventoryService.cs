using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Interfaces
{
    public interface IInventoryService
    {
        IQueryable<Inventory> ListAll(Expression<Func<Inventory, bool>> filter = null, Expression<Func<Inventory, int>> sortOrder = null);
        Inventory Create(Inventory inventory);
        Inventory Delete(Guid guid);
        Inventory Update(Guid guid,Inventory newInventory);  
    }
}
