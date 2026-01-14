using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.GeneralSpecialOfferDto;
using Udemy.WebUI.Services.CatalogServices.GeneralSpecialOfferServices;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _GeneralSpecialOfferComponentPartial : ViewComponent
    {
        private readonly IGeneralSpecialOfferService _generalSpecialOffer;

        public _GeneralSpecialOfferComponentPartial(IGeneralSpecialOfferService generalSpecialOffer)
        {
            _generalSpecialOffer = generalSpecialOffer;
        }

        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _generalSpecialOffer.GetAllGeneralSpecialOfferAsync();
            return View(values);
        }
    }
}
