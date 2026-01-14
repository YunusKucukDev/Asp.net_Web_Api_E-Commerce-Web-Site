using System.Text.Json;
using Udemy.Basket.Dtos;
using Udemy.Basket.Settings;

namespace Udemy.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string id)
        {
           await _redisService.GetDb().KeyDeleteAsync(id);
        }

        public async Task<BasketTotalDto> GetBasket(string id)
        {
            var existBasket= await _redisService.GetDb().StringGetAsync(id);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
            
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
