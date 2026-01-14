using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.ProductDetailDtos;
using Udemy.WebUI.Services.CatalogServices.ProductDetailServices;

namespace Udemy.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
        }
    }
}
