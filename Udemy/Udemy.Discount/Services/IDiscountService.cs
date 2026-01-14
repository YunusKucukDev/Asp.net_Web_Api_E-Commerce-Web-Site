using Udemy.Discount.Dtos;

namespace Udemy.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResutCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCoupunDto createCoupunDto);
        Task DeleteCoupunAsync(int id);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task<ResutCouponDto> GetCodeDetailByCodeAsync(string code);

        int GetDiscountCouponRate(string code);
    }
        
}
