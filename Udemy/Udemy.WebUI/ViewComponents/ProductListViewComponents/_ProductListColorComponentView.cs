using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListColorComponentView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
