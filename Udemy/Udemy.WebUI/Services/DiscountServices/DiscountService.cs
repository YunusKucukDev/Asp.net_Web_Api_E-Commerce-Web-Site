using SharpCompress.Readers;
using Udemy.DtoLayer.DiscountDtos;

namespace Udemy.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {

        private readonly HttpClient _httpclient;

        public DiscountService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpclient.GetAsync($"discounts/GetCodeDetailByCode/{code}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            var responseMessage = await _httpclient.GetAsync($"discounts/GetDiscountCouponRate/{code}");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
