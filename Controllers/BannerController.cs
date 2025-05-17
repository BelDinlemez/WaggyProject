using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    [Authorize]
    //primary Constructor

    public class BannerController(WaggyContext _context) : Controller
    {
       
            public IActionResult Index()
            {
                var values = _context.Banners.ToList();
                return View(values);
            }

            public IActionResult DeleteBanner(int id)
            {
                var values = _context.Banners.Find(id);
                _context.Remove(values);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            public IActionResult AddBanner()
            {
                return View();

            }

            [HttpPost]
            public IActionResult AddBanner(Banner model)

            {

                //Fast fail yöntemi
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            public IActionResult UpdateBanner(int id)
            {

                var values = _context.Banners.Find(id);
                return View(values);
            }

            [HttpPost]
            public IActionResult UpdateBanner(Banner model)
            {
                //Fast fail yöntemi
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _context.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");


            }
        }
}
