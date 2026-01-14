using System.Net.Http.Json;
using Udemy.DtoLayer.CatalogDtos.ProductImagesDtos;

namespace Udemy.WebUI.Services.CatalogServices.ProductImagesServices
{
    public class ProductImageService : IProductImageService
    {

        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductsImageDto createProductsImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductsImageDto>("productimages", createProductsImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimages?id=" + id);
        }

        public async Task<List<ResultProductsImageDto>> GetAllProductImagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultProductsImageDto>>();
            return values;
        }

        public async Task<UpdateProductsImageDto> GetByIdProductsImageDtoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductsImageDto>();
            return values;
        }

        public async Task<UpdateProductsImageDto> GetByProductIdProductsImageDtoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/ProductImagesByProductId?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductsImageDto>();
            return values;
        }

        public async Task UpdateProductImageAsync(UpdateProductsImageDto updateProductsImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductsImageDto>( "productimages", updateProductsImageDto);
        }
    }
}
