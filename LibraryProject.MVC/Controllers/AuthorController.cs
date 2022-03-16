using LibraryProject.Backend.Domain.Model;
using LibraryProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace LibraryProject.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorservice;

        public AuthorController(IAuthorService authorservice)
        {
            _authorservice = authorservice;
        }

       [HttpGet()]
       public IActionResult Index(string filter)
        {
            Expression<Func<Author, bool>> filterE = null;

            if (!string.IsNullOrEmpty(filter))
            {;
                filterE = s => s.Email.Contains(filter);
            }

            List<Author> model = _authorservice.List(filterE).ToList();
            return View(model);
        }
    }
}
