using Udemy.Catalog.DTOs.CategoryDtos;
using Udemy.Catalog.DTOs.GeneralSpecialOfferDtos;

namespace Udemy.Catalog.Services.GenerealSpecialOfferService
{
    public interface IGeneralSpecialOfferService
    {
        Task<List<ResultGeneralSpecialOfferDto>> GetAllGeneralSpecialOfferAsync();
        Task CreateGeneralSpecialOfferAsync(CreateGeneralSpecialOfferDto createGeneralSpecialOfferDto);
        Task UpdateGeneralSpecialOfferAsync(UpdateGeneralSpecialOfferDto updateGeneralSpecialOfferDto);
        Task DeleteGeneralSpecialOfferAsync(string id);
        Task<GetByIdGeneralSpecialOfferDto> GetByIdGeneralSpecialOfferAsync(string id);
    }
}
