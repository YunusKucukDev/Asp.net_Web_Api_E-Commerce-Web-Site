using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.FeatureSliderDto;
using Udemy.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial :ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureslider();
            return View(values);
        }
    }
}
