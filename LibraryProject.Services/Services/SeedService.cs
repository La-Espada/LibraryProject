using Bogus;
using LibraryDb.Domain.Model;
using LibraryDb.Infrastructure;
using LibraryProject.Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Services
{
    public class SeedService
    {
            private readonly LibraryContext _libraryContext;

            public SeedService(LibraryContext libraryContext)
            {
                _libraryContext = libraryContext;
            }

            public void DeleteDatabase() => _libraryContext.Database.EnsureDeleted();
            public void CreateDatabase() => _libraryContext.Database.EnsureCreated();

            public void Seed()
            {
                Randomizer.Seed = new Random(28917);
                Random random = new Random();

            var author = new Faker<Author>("en").Rules((f, e) =>
            {
                e.FirstName = f.Name.FirstName();
                e.LastName= f.Name.LastName();
                Gender gender = f.Random.Enum<Gender>(new Gender[] { Gender.NA });
                e.Gender = gender;
                  e.Birthdate = f.Date.Between(new DateTime(1945), new DateTime(2020));
                e.AddressRecord = new AddressRecord(f.Address.StreetName(), f.Address.BuildingNumber(), f.Address.City(), f.Address.ZipCode(), f.Address.Country())
                {
                    Street = f.Address.StreetName(),
                    HouseNumber = f.Address.BuildingNumber(),
                    City = f.Address.City(),
                    ZipCode = f.Address.ZipCode(),
                    Country = f.Address.Country()
                };
                e.Email = $"{e.LastName}@gmail.com";
                e.Phonenumber = f.Phone.PhoneNumber();

            })
            .Generate(100)
            .ToList();

            var customer = new Faker<Customer>("en").Rules((f, e) =>
            {

                e.FirstName = f.Name.FirstName();
                e.LastName = f.Name.LastName();
                e.Birthdate = f.Date.Between(new DateTime(1945), new DateTime(2020));
                Gender gender = f.Random.Enum<Gender>(new Gender[] { Gender.NA });
                e.Gender = gender;
                e.AddressRecord = new AddressRecord(f.Address.StreetName(),f.Address.BuildingNumber(), f.Address.City(), f.Address.ZipCode(), f.Address.Country())
                {
                    Street = f.Address.StreetName(),
                    HouseNumber = f.Address.BuildingNumber(),
                    City = f.Address.City(),
                    ZipCode = f.Address.ZipCode(),
                    Country = f.Address.Country()
                };
                e.PhonenumberRecord = f.Phone.PhoneNumber();
            }).Generate(100).ToList();

            //  var book2 = new Faker<Book>("en").Rules((f, e) =>
            // {
            //    e.Vorfolger = null;
            //  e.BookName = f.Company.CompanyName();
            // e.pageNumber = f.Random.Number(1, 1000);
            // e.Author = f.Random.ListItem(author);
            //  }).Generate(100).ToList();

            var book = new Faker<Book>("en").Rules((f, e) =>
            {
                // e.Vorfolger = f.Random.ListItem(book2);
                e.BookName = f.Company.CompanyName();
                e.PageNumber = f.Random.Number(1, 1000);
                e.Author= f.Random.ListItem(author);
            }).Generate(100).ToList();

            var library = new Faker<Library>("en").Rules((f, e) => {
                e.Name = f.Company.CompanyName();
                e.AddressRecord = new AddressRecord(f.Address.StreetName(), f.Address.BuildingNumber(), f.Address.City(), f.Address.ZipCode(), f.Address.Country())
                {
                    Street = f.Address.StreetName(),
                    HouseNumber = f.Address.BuildingNumber(),
                    City = f.Address.City(),
                    ZipCode = f.Address.ZipCode(),
                    Country = f.Address.Country()
                };
            }).Generate(100).ToList();

            var inventory = new Faker<Inventory>("en").Rules((f, e) =>
            {
                e.Book = f.Random.ListItem(book);
                e.Library = f.Random.ListItem(library);
                e.Amount = f.Random.Number(1, 1000);
            }).Generate(100).ToList();

            var lending = new Faker<Lending>("en").Rules((f, e) =>
            {
                e.Customer = f.Random.ListItem(customer);
                e.Inventory = f.Random.ListItem(inventory);
                e.Timeframe = f.Date.Between(DateTime.Now, new DateTime(2022));
            }).Generate(1000).ToList();

            _libraryContext.AddRange(author);
            _libraryContext.SaveChanges();
            _libraryContext.AddRange(customer);
            _libraryContext.SaveChanges();
            _libraryContext.AddRange(book);
            _libraryContext.SaveChanges();
            _libraryContext.AddRange(library);
            _libraryContext.SaveChanges();
            _libraryContext.AddRange(inventory);
            _libraryContext.SaveChanges();
            _libraryContext.AddRange(lending);
            _libraryContext.SaveChanges();




        }
         public void listDataAuthor()
        {
            foreach(Author author in _libraryContext.Authors)
            {
                Console.WriteLine(author.Id + " ," + author.FirstName + " ," + author.LastName + " ," + author.Birthdate + " ," + author.Phonenumber + " ," + author.AddressRecord.Street + " " );
            }
        }
        public void listDataBooks()
        {
            foreach (Book book in _libraryContext.Books)
            {
                Console.WriteLine(book.Id + " ," + book.AuthorId + " ," + book.BookName + " ," + book.PageNumber);
            }
        }
        public void listDataCustomer()
        {
            foreach (Customer customer in _libraryContext.Customers)
            {
                Console.WriteLine(customer.Id + " ," + customer.FirstName + " ," + customer.LastName + " ," + customer.Birthdate + " ," + customer.PhonenumberRecord + " ," + customer.AddressRecord.Street + " ");
            }
        }

        public void listDataInventory()
        {
            foreach (Inventory inventory in _libraryContext.Inventory)
            {
                Console.WriteLine(inventory.Id + " ," + inventory.LibraryId + " ," + inventory.Amount + " ," + inventory.BookId);
            }
        }

        public void listDataLending()
        {
            foreach (Lending lending in _libraryContext.Lendings)
            {
                Console.WriteLine(lending.Id + " ," + lending.InventoryId + " ," + lending.CustomerId + " ," + lending.Timeframe);
            }
        }

        public void listDataLibrary()
        {
            foreach(Library library in _libraryContext.Librarys)
            {
                Console.WriteLine(library.Id + " ," + library.Name + " ," + library.AddressRecord);
            }
        }
    }
}
