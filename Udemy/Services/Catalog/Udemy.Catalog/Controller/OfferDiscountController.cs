using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Catalog.DTOs.OfferDiscountDtos;
using Udemy.Catalog.Services.OfferDiscountService;

namespace Udemy.Catalog.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountController : ControllerBase
    {
        private readonly IOfferDiscountService _OfferDiscountervice;

        public OfferDiscountController(IOfferDiscountService OfferDiscountervice)
        {
            _OfferDiscountervice = OfferDiscountervice;
        }

        [HttpGet]
        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await _OfferDiscountervice.GetAllOfferDiscountAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByidOfferDiscount(string id)
        {
            var values = await _OfferDiscountervice.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _OfferDiscountervice.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Kategori Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _OfferDiscountervice.DeleteOfferDiscountAsync(id);
            return Ok("OfferDiscount Başarıyla Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _OfferDiscountervice.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
