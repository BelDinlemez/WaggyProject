using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly WaggyContext _context;

        public CategoryController (WaggyContext context)
        {
           _context= context;
        }

        public IActionResult Index()
        {
            var values = _context.Categories.ToList();
            return View(values);
           
        }

        public IActionResult AddCategory() 
        {
            return View();
     
        }

        [HttpPost]
        public IActionResult AddCategory( Category Model)
            
        {
            _context.Add(Model);
           _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteCategory( int id)
        {
            var values = _context.Categories.Find(id);
            _context.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory(int id)
        { 
            var values = _context.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}
