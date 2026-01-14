using Udemy.DtoLayer.CatalogDtos.AboutDtos;

namespace Udemy.WebUI.Services.CatalogServices.AboutServices
{
    public class Aboutservice : IAboutService
    {

        private readonly HttpClient _httpClient;

        public Aboutservice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public  async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("about", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("about?id=" + id);

        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var responseMessage = await _httpClient.GetAsync("about");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultAboutDto>>();
            return values;
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("about/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
            return values;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("about", updateAboutDto);
        }
    }
}
