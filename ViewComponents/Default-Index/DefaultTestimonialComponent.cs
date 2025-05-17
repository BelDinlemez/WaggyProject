using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents.Default_Index
{
    public class DefaultTestimonialComponent : ViewComponent
    {
        private readonly WaggyContext _context;

        public DefaultTestimonialComponent(WaggyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }
    }
}
