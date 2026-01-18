using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderDetailViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
