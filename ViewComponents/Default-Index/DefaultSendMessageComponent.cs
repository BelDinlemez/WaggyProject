using Microsoft.AspNetCore.Mvc;
using WaggyProject.Entities;

namespace WaggyProject.ViewComponents.Default_Index
{
    public class DefaultSendMessageComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

        

}
}