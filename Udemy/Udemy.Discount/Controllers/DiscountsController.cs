using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        [HttpGet("GetCodeDetailByCodeAsync")]
        public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        {
            var values = await _service.GetCodeDetailByCodeAsync(code);
            return Ok(values);
        }

        [HttpGet("GetDiscountCouponRate/{code}")]
        public  async Task<IActionResult> GetDiscountCouponRate(string code)
        {
            var values = await  _service.GetDiscountCouponRate(code);
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

        [HttpGet("GetDiscountCouponCount")]
        public async Task<IActionResult> GetDiscountCouponCount()
        {
            var values = await _service.GetDiscountCouponCount();
            return Ok(values);
        }
    }
}
