using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;
using Microsoft.EntityFrameworkCore;


namespace WaggyProject.ViewComponents.AdminLayout
{
    public class _MessagesDropdownComponentPartial : ViewComponent
    {
        WaggyContext _context = new WaggyContext();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Messages
         .Where(x => !x.IsRead)  // sadece okunmamışlar
         .OrderByDescending(x => x.MessageId)
         .Take(4)
         .ToListAsync();

            return View(values);
        }
    }
}
