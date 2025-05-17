using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.ViewComponents.AdminLayout
{
    public class AdminLayoutNavbarComponent: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly WaggyContext _context;

        public AdminLayoutNavbarComponent(UserManager<AppUser> userManager, WaggyContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var userName = User.Identity.Name;

            var user=await _userManager.FindByNameAsync(userName);
            ViewBag.fullName= String.Join(" ", user.FirstName,user.LastName);

            ViewBag.UnreadCount = await _context.Messages.CountAsync(m => !m.IsRead);

            ViewBag.userName = userName;
            return View();

        }
    }
}
