using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Catalog.DTOs.CategoryDtos;
using Udemy.Catalog.DTOs.ProductDtos;
using Udemy.Catalog.Services.ProductServices;
using static MongoDB.Driver.WriteConcern;

namespace Udemy.Catalog.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProductAsync();
            return Ok(result);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var result = await _productService.GetProductsWithCategoryAsync();
            return Ok(result);
        }

        [HttpGet("ProductListWithByCategoryIdCategory")]
        public async Task<IActionResult> ProductListWithByCategoryIdCategory(string id)
        {
            var result = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProducts(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }

        

        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto );
            return Ok("Ürün Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün Başarıyla Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }


    }
}
