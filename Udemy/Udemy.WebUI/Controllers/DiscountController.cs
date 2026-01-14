using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;
using Udemy.WebUI.Services.BasketServices;
using Udemy.WebUI.Services.DiscountServices;

namespace Udemy.WebUI.Controllers
{
    public class DiscountController : Controller
    {

        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult  ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {

            var values = await _discountService.GetDiscountCouponRate(code);
            var basketvalues = await _basketService.GetBasket();
            var tax = (basketvalues.TotalPrice * 10) / 100;
            var totalPriceWithTax = basketvalues.TotalPrice + (tax);
            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            return RedirectToAction("Index", "ShoppingCart", new { code = code , discountRate = values });
           
        }
    }
}
