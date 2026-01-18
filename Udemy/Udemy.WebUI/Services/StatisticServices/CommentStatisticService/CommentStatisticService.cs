
using Udemy.DtoLayer.CommnetDtos;

namespace Udemy.WebUI.Services.StatisticServices.CommentStatisticService
{
    public class CommentStatisticService : ICommentStatisticService
    {

        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> ActiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/ActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> PasiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/PasiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> TotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/TotalCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
