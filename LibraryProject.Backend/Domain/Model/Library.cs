using LibraryProject.Backend.Domain.Model;
using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Domain.Model
{
    public class Library: EntityBase
    {
        public Library() { }

        public Library(int id,AddressRecord addressRecord, string name)
        {
            Id = id;
            AddressRecord = addressRecord; 
            Name = name;
        }
        public Guid guid { get; set; }
        public int Id { get; private set; }
        public AddressRecord AddressRecord { get; set; }

        public string Name { get; set; } = string.Empty;

        private List<Inventory> _inventories = new();

        public IReadOnlyList<Inventory> Inventories => _inventories;

        public void AddInventory(Inventory inventory)
        {
            if(inventory is not null)
            {
               _inventories.Add(inventory);
            }
        }
    }
}
