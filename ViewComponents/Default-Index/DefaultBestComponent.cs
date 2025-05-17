using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.ViewComponents.Default_Index
{
    public class DefaultBestComponent: ViewComponent
    {
        private readonly WaggyContext _context;

        public DefaultBestComponent(WaggyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Products
             .OrderBy(x => Guid.NewGuid())
             .Take(5)
             .ToList();

            return View(values);
        }
    }
}
