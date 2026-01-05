using Udemy.Catalog.DTOs.ProductImagesDtos;

namespace Udemy.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductsImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductsImageDto createProductsImageDto);
        Task UpdateProductImageAsync(UpdateProductsImageDto updateProductsImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductsImageDto> GetByIdProductsImageDtoAsync(string id);
        Task <GetByIdProductsImageDto> GetByProductIdProductsImageDtoAsync(string id);
        
    }
}
