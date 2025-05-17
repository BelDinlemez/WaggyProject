using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;

namespace WaggyProject.Controllers
{

    [Authorize]
    public class MessageController : Controller
    {
        WaggyContext context = new WaggyContext();
        public IActionResult Index()
        {
            var values = context.Messages.ToList();
            return View(values);
        }
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = context.Messages.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = context.Messages.Find(id);

            if (value == null)
            {
                return NotFound(); // veya View("Error")
            }

            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
    }
}
