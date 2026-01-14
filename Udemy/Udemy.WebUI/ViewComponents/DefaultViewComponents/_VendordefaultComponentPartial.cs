using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.BrandDto;
using Udemy.WebUI.Services.CatalogServices.BrandServices;


namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendordefaultComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _VendordefaultComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}
