
namespace Udemy.WebUI.Services.StatisticServices.MessageStatisticService
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetTotalMessageCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
