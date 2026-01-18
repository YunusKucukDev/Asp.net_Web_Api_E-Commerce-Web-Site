
namespace Udemy.WebUI.Services.StatisticServices.DiscountstatisticService
{
    public class DiscountstatisticService : IDiscountstatisticService
    {
        private readonly HttpClient _httpClient;

        public DiscountstatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCount()
        {
            var responseMessage = await _httpClient.GetAsync("Discounts/GetDiscountCouponCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}

