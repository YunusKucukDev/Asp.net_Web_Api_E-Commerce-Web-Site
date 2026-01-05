using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.OfferDiscountDto;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentResult : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OfferDiscountDefaultComponentResult(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

       
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/OfferDiscount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
