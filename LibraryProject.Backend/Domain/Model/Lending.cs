using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Domain.Model
{
    public class Lending: EntityBase
    {
        public Lending() { }

        public Lending(int id, Customer customer, Inventory inventory, DateTime timeframe)
        {
            Id = id;
            Customer = customer;
            Inventory = inventory; 
            Timeframe = timeframe;
        }
        public Guid guid { get; set; }
        public int Id { get; private set; }
        public virtual Customer Customer { get;  set; } = default!;
        public int CustomerId { get; set; }
        public virtual Inventory Inventory { get;  set; } =default!;
        public int InventoryId { get; set; }
        public DateTime Timeframe { get; set; }
    }
}
