using Udemy.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace Udemy.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task createProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task updateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task deleteProductDetailAsync(string id);
        Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<UpdateProductDetailDto> GetByProductIdProductDetailAsync(string id);
    }
}
