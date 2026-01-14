using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.CategoryDtos;
using Udemy.WebUI.Services.CatalogServices.CategoryServices;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesdefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoriesdefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
