using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.Areas.User.ViewComponents.UserLayoutViewComponent
{
    public class _UserLayoutViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
