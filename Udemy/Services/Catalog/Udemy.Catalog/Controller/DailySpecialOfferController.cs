using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Catalog.DTOs.DailySpecialOfferDtos;
using Udemy.Catalog.Services.DailyspecialOfferService;


namespace Udemy.Catalog.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DailySpecialOfferController : ControllerBase
    {
        private readonly IDailySpecialOfferService _DailySpecialOfferService;

        public DailySpecialOfferController(IDailySpecialOfferService DailySpecialOfferService)
        {
            _DailySpecialOfferService = DailySpecialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> DailySpecialOfferList()
        {
            var values = await _DailySpecialOfferService.GetAllDailySpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByidDailySpecialOffer(string id)
        {
            var values = await _DailySpecialOfferService.GetByIdDailySpecialOfferAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDailySpecialOffer(CreateDailySpecialOfferDto createDailySpecialOfferDto)
        {
            await _DailySpecialOfferService.CreateDailySpecialOfferAsync(createDailySpecialOfferDto);
            return Ok("Günlük Özel İndirimler Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDailySpecialOffer(string id)
        {
            await _DailySpecialOfferService.DeleteDailySpecialOfferAsync(id);
            return Ok("Günlük Özel İndirimler Başarıyla Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateDailySpecialOffer(UpdateDailySpecialOfferDto updateDailySpecialOfferDto)
        {
            await _DailySpecialOfferService.UpdateDailySpecialOfferAsync(updateDailySpecialOfferDto);
            return Ok("Günlük Özel İndirimler Başarıyla Güncellendi");
        }
    }
}
