using Microsoft.AspNetCore.Mvc;
using Udemy.DtoLayer.BasketDtos;
using Udemy.WebUI.Services.BasketServices;
using Udemy.WebUI.Services.CatalogServices.ProductServices;

namespace Udemy.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult>   Index(string code , int discountRate, decimal totalNewPriceWithDiscount)
        {

            ViewBag.code = code;
            ViewBag.discountRate = discountRate;

            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var tax = (values.TotalPrice * 10) / 100;
            var totalPriceWithTax = values.TotalPrice + (tax) ;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            ViewBag.tax = tax;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                ProductImageUrl =values.ProductImageUrl,
                Quantity = 1 
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
