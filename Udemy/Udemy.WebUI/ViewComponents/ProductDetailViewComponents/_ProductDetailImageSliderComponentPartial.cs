using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

using Udemy.DtoLayer.CatalogDtos.CategoryDtos;
using Udemy.DtoLayer.CatalogDtos.ProductDtos;
using Udemy.DtoLayer.CatalogDtos.ProductImagesDtos;
using Udemy.WebUI.Services.CatalogServices.CategoryServices;
using Udemy.WebUI.Services.CatalogServices.ProductImagesServices;

namespace Udemy.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
       
        private readonly ICategoryService _categoryService;
        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(ICategoryService categoryService, IProductImageService productImageService)
        {
            _categoryService = categoryService;
            _productImageService = productImageService;
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


        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            await GetCategoriesInProducts();


            var values = await _productImageService.GetByProductIdProductsImageDtoAsync(id);
            return View(values);
        }
    }
}
