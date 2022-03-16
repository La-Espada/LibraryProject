using LibraryProject.Backend.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Backend.Infrastructure
{
    #nullable enable
    public class LibraryContext : DbContext
    {
        public LibraryContext ()
        {

        }

        public LibraryContext(DbContextOptions options): base(options){ }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Inventory> Inventory => Set<Inventory>();
        public DbSet<Lending> Lendings => Set<Lending>();
        public DbSet<Library> Librarys => Set<Library>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=Library.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().OwnsOne(s => s.AddressRecord);
            modelBuilder.Entity<Customer>().OwnsOne(s => s.AddressRecord);
        }

        

    }
}
