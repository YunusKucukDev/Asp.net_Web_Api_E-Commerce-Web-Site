using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListSizeFilterComponentView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
