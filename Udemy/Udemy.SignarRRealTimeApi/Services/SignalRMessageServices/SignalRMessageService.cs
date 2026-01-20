
namespace Udemy.SignarRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByRecceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetTotalMessageCountByRecceiverId?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
