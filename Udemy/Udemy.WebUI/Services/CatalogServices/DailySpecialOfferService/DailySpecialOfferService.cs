using System.Net.Http.Json;
using Udemy.DtoLayer.CatalogDtos.DailySpecialOfferDto;

namespace Udemy.WebUI.Services.CatalogServices.DailySpecialOfferService
{
    public class DailySpecialOfferService : IDailySpecialOfferService
    {

        private readonly HttpClient _httpClient;

        public DailySpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDailySpecialOfferAsync(CreateDailySpecialOfferDto createDailySpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDailySpecialOfferDto>("dailySpecialOffer", createDailySpecialOfferDto);
        }

        public async Task DeleteDailySpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("dailySpecialOffer?id=" + id);
        }

        public  async Task<List<ResultDailySpecialOfferDto>> GetAllDailySpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("dailySpecialOffer");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultDailySpecialOfferDto>>();

            return values;
        }

        public async Task<UpdateDailySpecialOfferDto> GetByIdDailySpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("dailySpecialOffer/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateDailySpecialOfferDto>();
            return values;
        }

        public async Task UpdateDailySpecialOfferAsync(UpdateDailySpecialOfferDto updateDailySpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDailySpecialOfferDto>("dailySpecialOffer", updateDailySpecialOfferDto);
        }
    }
}
