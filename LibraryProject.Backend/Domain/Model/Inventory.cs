using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Domain.Model
{
    public  class Inventory: EntityBase
    {
        public Inventory() { }

        public Inventory(int id, Book book, Library library, int amount)
        {
            Id = id;
            Book = book;
            Library = library;
            Amount = amount;
        }
        public Guid guid { get; set; }
        public int Id { get; private set; }
        public int BookId { get; set; }
        public virtual Book Book { get;  set; } = default!;
        public int LibraryId { get; set; }
        public virtual Library Library { get;  set; } = default!;
        public decimal Amount { get; set; }
        private List<Lending> _lendings = new();
        public IReadOnlyList<Lending> Lendings => _lendings; 
        
        public void AddLending(Lending lending)
        {
            if(lending is not null)
            {
                _lendings.Add(lending); 
            }
        }
        
    }
}
