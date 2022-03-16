using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Domain.Model
{
    public class Book: EntityBase
    {
        public Book() { }

        public Book(int id,string bookName,int pageNumber, Author author)
        {
            Id = id;
           BookName = bookName;
           PageNumber = pageNumber;
           Author = author;
        }

        public Guid guid { get; set; }
        public int Id { get; private set; }
        // public Book? Vorfolger { get; set; } = null;
        // public int VorfolgerId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; } = default!;
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
