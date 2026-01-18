using Microsoft.AspNetCore.Mvc;
using Udemy.WebUI.Services.BasketServices;

namespace Udemy.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryViewComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryViewComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTtoal = await _basketService.GetBasket();
            var basketitems = basketTtoal.BasketItems;
            return View(basketitems);
        }
    }
}
