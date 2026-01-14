using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.DailySpecialOfferDto;
using Udemy.WebUI.Services.CatalogServices.DailySpecialOfferService;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DailySpecialOfferComponentPartial :ViewComponent
    {
        private readonly IDailySpecialOfferService _dailySpecialOfferService;

        public _DailySpecialOfferComponentPartial(IDailySpecialOfferService dailySpecialOfferService)
        {
            _dailySpecialOfferService = dailySpecialOfferService;
        }

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dailySpecialOfferService.GetAllDailySpecialOfferAsync();
            return View(values);
        }
    }
}
