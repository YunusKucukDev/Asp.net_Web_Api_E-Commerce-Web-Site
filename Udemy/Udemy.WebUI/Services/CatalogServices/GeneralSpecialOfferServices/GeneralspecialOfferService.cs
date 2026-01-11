using Udemy.DtoLayer.CatalogDtos.GeneralSpecialOfferDto;

namespace Udemy.WebUI.Services.CatalogServices.GeneralSpecialOfferServices
{
    public class GeneralspecialOfferService :IGeneralSpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public GeneralspecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateGeneralSpecialOfferAsync(CreateGeneralSpecialOfferDto createGeneralSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateGeneralSpecialOfferDto>("GeneralSpecialOffer", createGeneralSpecialOfferDto);
        }

        public async Task DeleteGeneralSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("GeneralSpecialOffer?id=" + id);
        }

        public async Task<List<ResultGeneralSpecialOfferDto>> GetAllGeneralSpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("GeneralSpecialOffer");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultGeneralSpecialOfferDto>>();

            return values;
        }

        public async Task<UpdateGeneralSpecialOfferDto> GetByIdGeneralSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("GeneralSpecialOffer/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateGeneralSpecialOfferDto>();
            return values;
        }

        public async Task UpdateGeneralSpecialOfferAsync(UpdateGeneralSpecialOfferDto updateGeneralSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateGeneralSpecialOfferDto>("GeneralSpecialOffer", updateGeneralSpecialOfferDto);
        }
    }
}
