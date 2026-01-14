using Udemy.DtoLayer.CommnetDtos;

namespace Udemy.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {

        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async  Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/CommentListByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("comments?id=" + id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comment/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return values;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }
    }
}
