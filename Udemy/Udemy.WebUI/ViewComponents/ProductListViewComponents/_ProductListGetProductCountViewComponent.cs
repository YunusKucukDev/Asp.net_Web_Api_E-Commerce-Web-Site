using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListGetProductCountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
