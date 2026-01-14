using Udemy.DtoLayer.DiscountDtos;

namespace Udemy.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
        Task<int> GetDiscountCouponRate(string code);

    }
}
