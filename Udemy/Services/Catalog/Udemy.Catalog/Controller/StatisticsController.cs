using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Catalog.Services.StatisticServices;

namespace Udemy.Catalog.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {

        private readonly IStatisticServices _statisticServices;

        public StatisticsController(IStatisticServices statisticServices)
        {
            _statisticServices = statisticServices;
        }

        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var values = _statisticServices.GetBrandCount();
            return Ok(values);
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var values = _statisticServices.GetCategoryCount();
            return Ok(values);
        }


        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var values = _statisticServices.GetProductCount();
            return Ok(values);
        }


        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var values = await _statisticServices.GetProductAvgPrice();
            return Ok(values);
        }

        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var values = await _statisticServices.GetMaxPriceProductName();
            return Ok(values);
        }

        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var values = await _statisticServices.GetMinPriceProductName();
            return Ok(values);
        }
    }
}
