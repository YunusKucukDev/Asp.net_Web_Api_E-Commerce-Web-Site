using System.Net.Http.Json;
using Udemy.DtoLayer.CargoDtos.CargoCompanydtos;

namespace Udemy.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {

        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanDto>("cargoCompany", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargoCompany?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargoCompany");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultCargoCompanyDto>>();
            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("cargoCompany/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return values;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargoCompany", updateCargoCompanyDto);
        }
    }
}
