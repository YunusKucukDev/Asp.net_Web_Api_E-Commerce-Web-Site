using AutoMapper;
using MongoDB.Driver;
using Udemy.Catalog.DTOs.GeneralSpecialOfferDtos;
using Udemy.Catalog.Entities;
using Udemy.Catalog.settings;

namespace Udemy.Catalog.Services.GenerealSpecialOfferService
{
    public class GeneralSpecialOfferService : IGeneralSpecialOfferService
    {
        private readonly IMongoCollection<GeneralSpecialOffer> _GeneralSpecialOfferCollection;
        private readonly IMapper _mapper;

        public GeneralSpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _GeneralSpecialOfferCollection = database.GetCollection<GeneralSpecialOffer>(_databaseSettings.GeneralSpecialOfferCollectionName);
            _mapper = mapper;

        }

        public async Task CreateGeneralSpecialOfferAsync(CreateGeneralSpecialOfferDto createGeneralSpecialOfferDto)
        {
            var value = _mapper.Map<GeneralSpecialOffer>(createGeneralSpecialOfferDto);
            await _GeneralSpecialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteGeneralSpecialOfferAsync(string id)
        {
            await _GeneralSpecialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultGeneralSpecialOfferDto>> GetAllGeneralSpecialOfferAsync()
        {
            var values = await _GeneralSpecialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultGeneralSpecialOfferDto>>(values);
        }

        public async Task<GetByIdGeneralSpecialOfferDto> GetByIdGeneralSpecialOfferAsync(string id)
        {
            var values = await _GeneralSpecialOfferCollection.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdGeneralSpecialOfferDto>(values);
        }

        public async Task UpdateGeneralSpecialOfferAsync(UpdateGeneralSpecialOfferDto updateGeneralSpecialOfferDto)
        {
            var value = _mapper.Map<GeneralSpecialOffer>(updateGeneralSpecialOfferDto);
            await _GeneralSpecialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateGeneralSpecialOfferDto.SpecialOfferId, value);
        }
    }
}
