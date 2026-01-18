using Udemy.DtoLayer.OrderDtos.OrderAddressDtos;

namespace Udemy.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateOrderAddressDtos createOrderAddressDtos)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDtos>("addresses", createOrderAddressDtos);
        }
    }
}
