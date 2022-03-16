using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.MVC.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
