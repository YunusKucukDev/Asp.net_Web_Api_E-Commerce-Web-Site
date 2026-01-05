using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Udemy.WebUI.Areas.Admin.ViewComponents._AdminLayoutViewHeadComponentPartial
{
    public class _AdminLayoutViewHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
