using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Domain.Model
{
    public enum Gender { NA = 0, FEMALE = 1, MALE = 2 }
    public class Author :EntityBase
    {
        public Author() { }

        public Author(int id,string firstname, string lastname, DateTime birthdate, AddressRecord addressRecord, string phonenumber, Gender gender, string email)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Birthdate = birthdate;
            AddressRecord = addressRecord;
            Phonenumber = phonenumber;
            Gender = gender;
            Email = email;

        }
        public Guid guid { get; set; }
        public int Id { get; private set; }
        public string FirstName { get;  set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate {get; set; }
        public AddressRecord AddressRecord { get; set; }
        public string Phonenumber { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        private List<Book> _books { get; set; } = new();
        public virtual IReadOnlyList<Book> Books => _books; 

        public void AddBook(Book book)
        {
            if(book is not null)
            {
                _books.Add(book);
            }
        }
    }
}
