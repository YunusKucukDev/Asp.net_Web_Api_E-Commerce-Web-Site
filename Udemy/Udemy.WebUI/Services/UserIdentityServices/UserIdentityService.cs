using Udemy.DtoLayer.UserDtos;

namespace Udemy.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentitySDervice
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAllUserAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:5001/api/users/GetAllUser");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserDto>>();
            return values;
        }
    }
}
