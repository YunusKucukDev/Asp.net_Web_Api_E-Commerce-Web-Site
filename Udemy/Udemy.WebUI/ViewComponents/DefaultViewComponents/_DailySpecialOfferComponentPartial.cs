using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Udemy.DtoLayer.CatalogDtos.DailySpecialOfferDto;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DailySpecialOfferComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DailySpecialOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/DailySpecialOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDailySpecialOfferDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
