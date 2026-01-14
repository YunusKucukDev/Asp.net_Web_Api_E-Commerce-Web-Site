using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.OfferDiscountDto;
using Udemy.WebUI.Services.CatalogServices.OfferDiscountservices;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentResult : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountDefaultComponentResult(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values); 
        }
    }
}
