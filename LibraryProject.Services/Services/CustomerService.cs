
using LibraryProject.Backend.Domain.Model;
using LibraryProject.Backend.Exceptions;
using LibraryProject.Backend.Infrastructure;
using LibraryProject.Services.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private LibraryContext _libraryContext;

        public CustomerService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public Customer addCustomer(Customer customer, string vname)
        {
            try
            {
                bool x = _libraryContext.Customers.Any(e => e.FirstName == vname);
                if (!x)
                {
                    _libraryContext.Entry(customer).State = EntityState.Added;
                    _libraryContext.SaveChanges();
                }
            }
            catch (SqliteException ex)
            {
                throw new CustomerException("Datensatz existiert schon");
            }
            return customer;
        }

        public Customer deleteCustomer(int id)
        {
            try
            {
                var customer = _libraryContext.Customers.Find(id);
                _libraryContext.Entry(customer).State = EntityState.Deleted;
                return customer;
            }
            catch (SqliteException ex)
            {
                throw new CustomerException("Datensatz wurde nicht gefunden");
            }
        }

        public Customer getCustomerbyBirthdate(DateTime birthdate)
        {
            return _libraryContext.Customers.Where(c => c.Birthdate == birthdate).First();
        }

        public Customer update(int id, Customer newCustomer)
        {
            try
            {
                Customer? c = _libraryContext.Customers.Find(id);
                c = newCustomer;
                _libraryContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool x = _libraryContext.Customers.Any(e => e.Id == id);

                if (!x)
                {
                    throw new CustomerException("Datensatz wurde nicht gefunden!");
                }

            }

            return newCustomer;
        }
    }
}
