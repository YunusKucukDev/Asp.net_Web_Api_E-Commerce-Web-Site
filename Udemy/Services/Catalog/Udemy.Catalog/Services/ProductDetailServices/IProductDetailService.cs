using Udemy.Catalog.DTOs.CategoryDtos;
using Udemy.Catalog.DTOs.ProductDetailDtos;
using Udemy.Catalog.DTOs.ProductDtos;

namespace Udemy.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task createProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task updateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task deleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
    }
}
