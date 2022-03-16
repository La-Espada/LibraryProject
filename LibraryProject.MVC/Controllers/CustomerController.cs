using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.MVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
