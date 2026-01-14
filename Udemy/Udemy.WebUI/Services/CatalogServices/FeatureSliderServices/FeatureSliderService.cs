using System.Net.Http.Json;
using Udemy.DtoLayer.CatalogDtos.FeatureSliderDto;

namespace Udemy.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {

        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featureslider", createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featureslider?id=" + id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureslider()
        {
            var responseMessage = await _httpClient.GetAsync("featureslider");

            if (!responseMessage.IsSuccessStatusCode)
            {
                var error = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {responseMessage.StatusCode} - {error}");
            }

            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultFeatureSliderDto>>();

            return values ?? new List<ResultFeatureSliderDto>();
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featureslider/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
            return values;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featureslider", updateFeatureSliderDto);
        }
    }
}
