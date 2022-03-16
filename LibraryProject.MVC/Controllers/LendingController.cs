using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.MVC.Controllers
{
    public class LendingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
