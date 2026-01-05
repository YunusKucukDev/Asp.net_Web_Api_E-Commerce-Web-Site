using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Discount.Dtos;
using Udemy.Discount.Services;

namespace Udemy.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {

        private readonly IDiscountService _service;

        public DiscountsController(IDiscountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _service.GetAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DiscountGetByIdCouponsAsync(int id)
        {
            var values = await _service.GetByIdCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> DiscountCreateCoupon(CreateCoupunDto coupon)
        {
            await _service.CreateCouponAsync(coupon);
            return Ok("Kupon Başarıyla oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DiscountDeleteCoupon(int id)
        {
            await _service.DeleteCoupunAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> DiscountUpdateCoupon(UpdateCouponDto updateCoupon)
        {
            await _service.UpdateCouponAsync(updateCoupon);
            return Ok("Kupon Başarıyla Güncellendi");

        }
    }
}
