using LibraryProject.Backend.Domain.Model;
using LibraryProject.Backend.Exceptions;
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
    public class InventoryService : IInventoryService
    {
        private readonly LibraryContext _libraryContext;

        public InventoryService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public IQueryable<Inventory> ListAll(Expression<Func<Inventory, bool>> filter = null, Expression<Func<Inventory, int>> sortOrder = null)
        {
            IQueryable<Inventory> inventories = _libraryContext.Inventory;

            if(filter != null || sortOrder != null)
            {
                inventories = inventories.Where(filter);
                inventories = inventories.OrderBy(filter);
            }

            return inventories;

        }
        public Inventory Create(Inventory inventory)
        {
            try
            {
                bool x = _libraryContext.Inventory.Any(e => e.Library.Id == inventory.Library.Id);
                if (!x)
                {
                    _libraryContext.Entry(inventory).State = EntityState.Added;
                    _libraryContext.SaveChanges();
                }
            }catch(EntryPointNotFoundException ex)
            {
                throw new EntryPointNotFoundException("Invetory already exists");
            }
            return inventory;
        }

        public Inventory Delete(Guid guid)
        {
            try
            {
                var inventory = _libraryContext.Inventory.Find(guid);
                if(inventory != null)
                {
                    _libraryContext.Entry(inventory).State = EntityState.Added;
                }
                return inventory;

            }catch(EntryPointNotFoundException ex)
            {
                throw new InventoryException("Inventory does not exist", ex);
            }
        }

        public Inventory Update(Guid guid,Inventory newInventory)
        {
            try
            {
                Inventory? inventory = _libraryContext.Inventory.Find(guid);
                inventory = newInventory;
                _libraryContext.SaveChanges();
            }catch(DbUpdateConcurrencyException ex)
            {
                bool x = _libraryContext.Inventory.Any(e => e.guid == guid);
                if (!x)
                {
                    throw new KeyNotFoundException("Inventory does not exist");
                }
               
            }
            return newInventory;
        }
    }
}
