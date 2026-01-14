using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Udemy.DtoLayer.CatalogDtos.CategoryDtos;
using Udemy.WebUI.Services.CatalogServices.CategoryServices;
using static MongoDB.Driver.WriteConcern;

namespace Udemy.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryservice;

        public _NavbarUILayoutComponentPartial(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryservice.GetAllCategoryAsync();
            return View(values);
        }
    }
}
