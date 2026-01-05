using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.ShopingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
