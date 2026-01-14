using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.CategoryDtos;
using Udemy.DtoLayer.CatalogDtos.ProductDtos;
using Udemy.WebUI.Services.CatalogServices.CategoryServices;
using Udemy.WebUI.Services.CatalogServices.ProductServices;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public _FeatureProductsDefaultComponentPartial(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            GetCategoriesInProducts();
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }


        private async Task GetCategoriesInProducts()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;
        }
    }
}
