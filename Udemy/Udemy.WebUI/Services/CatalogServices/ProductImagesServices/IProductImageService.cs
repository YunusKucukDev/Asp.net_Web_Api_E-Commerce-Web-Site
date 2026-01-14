using Udemy.DtoLayer.CatalogDtos.ProductImagesDtos;

namespace Udemy.WebUI.Services.CatalogServices.ProductImagesServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductsImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductsImageDto createProductsImageDto);
        Task UpdateProductImageAsync(UpdateProductsImageDto updateProductsImageDto);
        Task DeleteProductImageAsync(string id);
        Task<UpdateProductsImageDto> GetByIdProductsImageDtoAsync(string id);
        Task<UpdateProductsImageDto> GetByProductIdProductsImageDtoAsync(string id);
    }
}
