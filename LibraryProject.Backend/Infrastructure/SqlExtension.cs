using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Infrastructure
{
    public static class SqlExtension
    {
        public static void ConfigureSqLite(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<LibraryContext>(options => options.UseSqlite(connectionString));
        }
    }
}
