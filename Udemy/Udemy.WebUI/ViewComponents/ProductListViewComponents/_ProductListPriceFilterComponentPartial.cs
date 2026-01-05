using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListPriceFilterComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
