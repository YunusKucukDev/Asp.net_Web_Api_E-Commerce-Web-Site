using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.ShopingCartViewComponents
{
    public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
