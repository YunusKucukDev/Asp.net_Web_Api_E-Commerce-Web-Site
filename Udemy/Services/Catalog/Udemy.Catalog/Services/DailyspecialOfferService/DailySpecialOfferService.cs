using AutoMapper;
using MongoDB.Driver;
using Udemy.Catalog.DTOs.DailySpecialOfferDtos;
using Udemy.Catalog.Entities;
using Udemy.Catalog.settings;

namespace Udemy.Catalog.Services.DailyspecialOfferService
{
    public class DailySpecialOfferService : IDailySpecialOfferService
    {
        private readonly IMongoCollection<DailySpecialOffer> _DailySpecialOfferCollection;
        private readonly IMapper _mapper;

        public DailySpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _DailySpecialOfferCollection = database.GetCollection<DailySpecialOffer>(_databaseSettings.DailySpecialOfferCollectionName);
            _mapper = mapper;

        }

        public async Task CreateDailySpecialOfferAsync(CreateDailySpecialOfferDto createDailySpecialOfferDto)
        {
            var value = _mapper.Map<DailySpecialOffer>(createDailySpecialOfferDto);
            await _DailySpecialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteDailySpecialOfferAsync(string id)
        {
            await _DailySpecialOfferCollection.DeleteOneAsync(x => x.DailyspecialOfferId == id);
        }

        public async Task<List<ResultDailySpecialOfferDto>> GetAllDailySpecialOfferAsync()
        {
            var values = await _DailySpecialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDailySpecialOfferDto>>(values);
        }

        public async Task<GetByIdDailySpecialOfferDto> GetByIdDailySpecialOfferAsync(string id)
        {
            var values = await _DailySpecialOfferCollection.Find(x => x.DailyspecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDailySpecialOfferDto>(values);
        }

        public async Task UpdateDailySpecialOfferAsync(UpdateDailySpecialOfferDto updateDailySpecialOfferDto)
        {
            var value = _mapper.Map<DailySpecialOffer>(updateDailySpecialOfferDto);
            await _DailySpecialOfferCollection.FindOneAndReplaceAsync(x => x.DailyspecialOfferId == updateDailySpecialOfferDto.DailyspecialOfferId, value);
        }
    }
}
