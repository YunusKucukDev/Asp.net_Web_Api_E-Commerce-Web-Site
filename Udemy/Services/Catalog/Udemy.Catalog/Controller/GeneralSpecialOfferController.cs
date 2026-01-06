using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Catalog.DTOs.GeneralSpecialOfferDtos;
using Udemy.Catalog.Services.GenerealSpecialOfferService;

namespace Udemy.Catalog.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralSpecialOfferController : ControllerBase
    {
        private readonly IGeneralSpecialOfferService _GeneralSpecialOfferService;

        public GeneralSpecialOfferController(IGeneralSpecialOfferService GeneralSpecialOfferService)
        {
            _GeneralSpecialOfferService = GeneralSpecialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GeneralSpecialOfferList()
        {
            var values = await _GeneralSpecialOfferService.GetAllGeneralSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByidGeneralSpecialOffer(string id)
        {
            var values = await _GeneralSpecialOfferService.GetByIdGeneralSpecialOfferAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeneralSpecialOffer(CreateGeneralSpecialOfferDto createGeneralSpecialOfferDto)
        {
            await _GeneralSpecialOfferService.CreateGeneralSpecialOfferAsync(createGeneralSpecialOfferDto);
            return Ok("Genel Özel İndirimler Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGeneralSpecialOffer(string id)
        {
            await _GeneralSpecialOfferService.DeleteGeneralSpecialOfferAsync(id);
            return Ok("Genel Özel İndirimler Başarıyla Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateGeneralSpecialOffer(UpdateGeneralSpecialOfferDto updateGeneralSpecialOfferDto)
        {
            await _GeneralSpecialOfferService.UpdateGeneralSpecialOfferAsync(updateGeneralSpecialOfferDto);
            return Ok("Genel Özel İndirimler Başarıyla Güncellendi");
        }
    }
}
