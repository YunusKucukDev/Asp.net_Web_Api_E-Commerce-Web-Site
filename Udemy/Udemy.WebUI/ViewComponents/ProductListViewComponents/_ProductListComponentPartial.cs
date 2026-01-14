using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.CategoryDtos;
using Udemy.DtoLayer.CatalogDtos.ProductDtos;
using Udemy.WebUI.Services.CatalogServices.ProductServices;

namespace Udemy.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);
        }
    }
}
