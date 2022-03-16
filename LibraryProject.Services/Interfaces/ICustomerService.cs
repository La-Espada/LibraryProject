using LibraryDb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer addCustomer(Customer customer, string vname);
        Customer deleteCustomer(int id);
        Customer update(int id, Customer newCustomer);
        Customer getCustomerbyBirthdate(DateTime birthdate);
    }
}
