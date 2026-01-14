using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Catalog.DTOs.ProductDetailDtos;
using Udemy.Catalog.Services.ProductDetailServices;
using Udemy.Catalog.Services.ProductServices;

namespace Udemy.Catalog.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _service;

        public ProductDetailController(IProductDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _service.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByidProductDetail(string id)
        {
            var values = await _service.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpGet("GetByProductidProductDetail/{id}")]
        public async Task<IActionResult> GetByProductidProductDetail(string id)
        {
            var values = await _service.GetByProductIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _service.createProductDetailAsync(createProductDetailDto);
            return Ok("Product Detail Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _service.deleteProductDetailAsync(id);
            return Ok("Product Detail Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _service.updateProductDetailAsync(updateProductDetailDto);
            return Ok("Product Detail Güncellendi");
        }
    }
}
