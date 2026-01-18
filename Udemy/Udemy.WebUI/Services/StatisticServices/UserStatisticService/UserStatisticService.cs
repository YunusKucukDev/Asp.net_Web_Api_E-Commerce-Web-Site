

using Newtonsoft.Json;
using Udemy.DtoLayer.UserDtos;

namespace Udemy.WebUI.Services.StatisticServices.UserStatisticService
{
    public class UserStatisticService : IUserStatisticService
    {

        private readonly HttpClient _Client;

        public UserStatisticService(HttpClient client)
        {
            _Client = client;
        }

        public async Task<int> GetUserCount()
        {
            var responseMessage = await _Client.GetAsync("https://localhost:5001/api/statistics");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            return values;
        }
    }
}
