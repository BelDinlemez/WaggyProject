using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    [Authorize]
    //primary Constructor
    public class TestimonialController(WaggyContext _context) : Controller
    {

        public IActionResult Index()
        {
            var values=_context.Testimonials.ToList();
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var values = _context.Testimonials.Find(id);
            _context.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddTestimonial()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial model)

        {

            //Fast fail yöntemi
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult UpdateTestimonial(int id)
        {

            var values = _context.Testimonials.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial model)
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
