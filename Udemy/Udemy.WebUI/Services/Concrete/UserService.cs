using Udemy.WebUI.Models;
using Udemy.WebUI.Services.Interfaces;

namespace Udemy.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuserinfo");
        }
    }
}
