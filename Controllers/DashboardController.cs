using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        private readonly WaggyContext _context;

        public DashboardController(WaggyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalProducts = _context.Products.Count();
            ViewBag.TotalCategories = _context.Categories.Count();
            ViewBag.TotalMessages = _context.Messages.Count();
            ViewBag.TotalTestimonials = _context.Testimonials.Count();

            // Grafik için
            ViewBag.CategoryLabels = _context.Categories.Select(c => c.CategoryName).ToList();
            ViewBag.CategoryCounts = _context.Categories
                .Select(c => c.Products.Count).ToList();

            ViewBag.MonthLabels = new[] { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran" };
            ViewBag.MonthlyProductCounts = new[] { 2, 5, 3, 7, 4, 6 }; // örnek veri
            return View();
        }
    }
}
