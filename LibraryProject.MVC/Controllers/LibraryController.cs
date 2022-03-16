

using LibraryDb.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.MVC.Controllers
{
    public class LibraryController : Controller
    {

        private readonly LibraryContext _db;

        public LibraryController(LibraryContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            var objLibraryList = _db.Inventory.ToList();
            return View();
        }
    }
}
