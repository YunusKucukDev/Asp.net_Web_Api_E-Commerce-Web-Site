
using System.Text.Json;
using Udemy.DtoLayer.BasketDtos;

namespace Udemy.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {

        private readonly HttpClient _httpclient;
        public BasketService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if (values != null)
            {
                if(!values.BasketItems.Any(x => x.ProductId==basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values = new BasketTotalDto();
                    values.BasketItems.Add(basketItemDto);
                }
            }
            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var response = await _httpclient.GetAsync("baskets");
            var raw = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Basket API Error: {response.StatusCode} - {raw}");
            }

            var values = JsonSerializer.Deserialize<BasketTotalDto>(
                raw,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId==productId);  
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpclient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
