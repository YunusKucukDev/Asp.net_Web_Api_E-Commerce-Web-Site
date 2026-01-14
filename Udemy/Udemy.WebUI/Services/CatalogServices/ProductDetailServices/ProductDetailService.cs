

using Udemy.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace Udemy.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {

        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task createProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetail", createProductDetailDto);
        }

        public async Task deleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetail?id=" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetail");
            var values = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultProductDetailDto>>();
            return values;
        }

        public async Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetail/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return values;
        }

        public async Task<UpdateProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetail/GetByProductidProductDetail/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return values;
        }

        public async Task updateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetail", updateProductDetailDto);
        }
    }
}
