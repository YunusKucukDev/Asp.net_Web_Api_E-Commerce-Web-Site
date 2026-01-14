using Microsoft.AspNetCore.Mvc;
using Udemy.WebUI.Services.BasketServices;

namespace Udemy.WebUI.ViewComponents.ShopingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {

        private readonly IBasketService _basketService;

        public _ShoppingCartProductListComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult>  InvokeAsync()
        {
            var basketTtoal = await _basketService.GetBasket();
            var basketitems = basketTtoal.BasketItems;
            return View(basketitems);
        }
    }
}
