using Udemy.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace Udemy.WebUI.Services.CargoServices.CargocustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {

        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerById> GetByIdCargoCustomerAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargoCustomer/GetCargoCustomerById?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerById>();
            return values;
        }
    }
}
