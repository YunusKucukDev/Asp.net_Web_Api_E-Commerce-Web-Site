using AutoMapper;
using MongoDB.Driver;
using Udemy.Catalog.DTOs.AboutDto;
using Udemy.Catalog.Entities;
using Udemy.Catalog.settings;

namespace Udemy.Catalog.Services.AboutServices
{
    public class AboutServices : IAboutServices
    {
        private readonly IMongoCollection<About> _AboutCollection;
        private readonly IMapper _mapper;

        public AboutServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _AboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;

        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _AboutCollection.InsertOneAsync(value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _AboutCollection.DeleteOneAsync(x => x.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _AboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var values = await _AboutCollection.Find(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            await _AboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, value);
        }
    }
}

