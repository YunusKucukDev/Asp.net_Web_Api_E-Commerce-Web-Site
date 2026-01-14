using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.CategoryDtos;
using Udemy.DtoLayer.CatalogDtos.ProductDtos;
using Udemy.WebUI.Services.CatalogServices.CategoryServices;
using Udemy.WebUI.Services.CatalogServices.ProductServices;

namespace Udemy.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryservice;
        private readonly IProductService _productService;

        public _ProductDetailFeatureComponentPartial(IProductService productService, ICategoryService categoryservice)
        {
            _productService = productService;
            _categoryservice = categoryservice;
        }

        private async Task GetCategoriesInProducts()
        {

            var values = await _categoryservice.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;
        }

        
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            await GetCategoriesInProducts();

            var values = await _productService.GetByIdProductAsync(id);
            return View(values);
        }
    }
}
