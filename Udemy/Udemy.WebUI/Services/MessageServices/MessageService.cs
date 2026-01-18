using Udemy.DtoLayer.DiscountDtos;
using Udemy.DtoLayer.MessagesDtos;

namespace Udemy.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {

        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }


        public async Task<List<ResultInboxDto>> GetInboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7078/api/UserMessages/GetMesaageInBox?id="+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxDto>>();
            return values;
        }

        public async Task<List<ResultSendBoxDto>> GetSendBoxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7078/api/UserMessages/GetMesaageSendBox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendBoxDto>>();
            return values;
        }
    }
}
