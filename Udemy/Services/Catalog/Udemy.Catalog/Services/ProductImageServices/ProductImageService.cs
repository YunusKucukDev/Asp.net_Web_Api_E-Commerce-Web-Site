using AutoMapper;
using MongoDB.Driver;
using Udemy.Catalog.DTOs.ProductImagesDtos;
using Udemy.Catalog.Entities;
using Udemy.Catalog.settings;

namespace Udemy.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageServiceCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageServiceCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;

        }

        public async Task CreateProductImageAsync(CreateProductsImageDto createProductsImageDto)
        {
            var result = _mapper.Map<ProductImage>(createProductsImageDto);
            await _productImageServiceCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageServiceCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultProductsImageDto>> GetAllProductImagesAsync()
        {
            var results = await _productImageServiceCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductsImageDto>>(results);
        }

        public async Task<GetByIdProductsImageDto> GetByIdProductsImageDtoAsync(string id)
        {
            var result = await _productImageServiceCollection.Find(x=>x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductsImageDto>(result);
        }

        public async Task<GetByIdProductsImageDto> GetByProductIdProductsImageDtoAsync(string id)
        {
            var results = await _productImageServiceCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductsImageDto>(results);
        }

        public async Task UpdateProductImageAsync(UpdateProductsImageDto updateProductsImageDto)
        {
            var result = _mapper.Map<ProductImage>(updateProductsImageDto);
            await _productImageServiceCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductsImageDto.ProductId, result);
        }   
    }
}
