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
    public class Customer: EntityBase
    {
        public Customer() { }

        public Customer(int id,string firstname,string lastname, DateTime birthDate,AddressRecord addressRecord, string phonenumber)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Birthdate = birthDate;
            AddressRecord = addressRecord;
            PhonenumberRecord = phonenumber;
        }
        public Guid guid { get; set; }

        public int Id { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public AddressRecord AddressRecord { get; set; }
        public Gender Gender { get; set; }
        public string PhonenumberRecord { get; set; } = string.Empty;
        private List<Lending> _lendings = new();
        public IReadOnlyList<Lending> Lending => _lendings;

        public void AddLending(Lending lending)
        {
            if(lending is not null)
            {
                _lendings.Add(lending);
            }
        }

    }
}
