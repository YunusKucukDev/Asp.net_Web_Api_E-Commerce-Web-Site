using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Catalog.DTOs.ProductDetailDtos;
using Udemy.Catalog.DTOs.ProductImagesDtos;
using Udemy.Catalog.Services.ProductDetailServices;
using Udemy.Catalog.Services.ProductImageServices;

namespace Udemy.Catalog.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _service;

        public ProductImagesController(IProductImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _service.GetAllProductImagesAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByidCategory(string id)
        {
            var values = await _service.GetByIdProductsImageDtoAsync(id);
            return Ok(values);
        }

        [HttpGet("ProductImagesByProductId")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var values = await _service.GetByProductIdProductsImageDtoAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductsImageDto createProductsImageDto)
        {
            await _service.CreateProductImageAsync(createProductsImageDto);
            return Ok("Product Image Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _service.DeleteProductImageAsync(id);
            return Ok("Product Image Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateProductsImageDto updateProductsImageDto)
        {
            await _service.UpdateProductImageAsync(updateProductsImageDto);
            return Ok("Product Image Güncellendi");
        }
    }
}
