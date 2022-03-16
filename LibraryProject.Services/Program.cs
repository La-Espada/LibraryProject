// See https://aka.ms/new-console-template for more information
using LibraryDb.Infrastructure;
using LibraryProject.Services.Services;

SeedService db = new SeedService(new LibraryContext());
db.DeleteDatabase();
db.CreateDatabase();
db.Seed();
Console.WriteLine("##############AUTHOR#####################################################################");
db.listDataAuthor();
Console.WriteLine("##############BOOK#######################################################################");
db.listDataBooks();
Console.WriteLine("##############CUSTOMER###################################################################");
db.listDataCustomer();
Console.WriteLine("##############LIBRARY####################################################################");
db.listDataLibrary();
Console.WriteLine("##############INVENTORY##################################################################");
db.listDataInventory();
Console.WriteLine("##############LENDING####################################################################");
db.listDataLending();
