using AutoMapper;
using MongoDB.Driver;
using Udemy.Catalog.DTOs.CategoryDtos;
using Udemy.Catalog.DTOs.ProductDetailDtos;
using Udemy.Catalog.DTOs.ProductDtos;
using Udemy.Catalog.Entities;
using Udemy.Catalog.settings;

namespace Udemy.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;

        }

        public async Task createProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var result = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(result);
        }

        public async Task deleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var value = await _productDetailCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task updateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var result = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDetailDto.ProductId, result);
        }
    }
}
