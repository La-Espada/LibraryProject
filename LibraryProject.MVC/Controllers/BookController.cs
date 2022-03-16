using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.MVC.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
