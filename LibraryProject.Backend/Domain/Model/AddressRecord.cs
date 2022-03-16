using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Domain.Model;
    [Owned]
    public  record  AddressRecord(string Street,string HouseNumber, string City,string ZipCode,string Country);

}
