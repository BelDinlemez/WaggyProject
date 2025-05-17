using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents.Default_Index
{
    public class DefaultBannerComponent : ViewComponent
    {
        private readonly WaggyContext _context;

        public DefaultBannerComponent(WaggyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Banners.ToList();
            return View(values);
        }
    }
}
