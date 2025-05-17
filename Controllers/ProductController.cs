using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly WaggyContext _context;

        public ProductController(WaggyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return View(values);
        }

        public IActionResult AddProduct()
        {
            var categoryList= _context.Categories.ToList();
            ViewBag.categories =(from x in categoryList
                                 select new SelectListItem
                                 {
                                     Text=x.CategoryName,
                                     Value = x.CategoryId.ToString()
                                 }).ToList();


            return View();

        }

        [HttpPost]
        public IActionResult AddProduct(Product model)

        {

            if (model.ImageFile != null)
            {
                // Dosya yükleme işlemi
                var currentDirectory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var saveLocation = Path.Combine(currentDirectory, "wwwroot/images", fileName + extension);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                model.ImageUrl = "/images/" + fileName + extension;
            }
            else if (!string.IsNullOrEmpty(model.ImageUrl))
            {
                
            }
            else
            {
                
                ModelState.AddModelError("ImageFile", "Lütfen bir dosya yükleyin veya görsel URL'si girin.");
                return View(model); // Formu tekrar göster
            }

            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _context.Products.Find(id);
            _context.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(int id)
        {
            var categoryList = _context.Categories.ToList();
            ViewBag.categories = (from x in categoryList
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();

            var values = _context.Products.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
