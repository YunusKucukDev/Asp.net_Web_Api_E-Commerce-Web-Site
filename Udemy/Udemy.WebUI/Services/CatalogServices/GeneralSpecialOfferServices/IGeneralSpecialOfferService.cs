using Udemy.DtoLayer.CatalogDtos.GeneralSpecialOfferDto;

namespace Udemy.WebUI.Services.CatalogServices.GeneralSpecialOfferServices
{
    public interface IGeneralSpecialOfferService
    {
        Task<List<ResultGeneralSpecialOfferDto>> GetAllGeneralSpecialOfferAsync();
        Task CreateGeneralSpecialOfferAsync(CreateGeneralSpecialOfferDto createGeneralSpecialOfferDto);
        Task UpdateGeneralSpecialOfferAsync(UpdateGeneralSpecialOfferDto updateGeneralSpecialOfferDto);
        Task DeleteGeneralSpecialOfferAsync(string id);
        Task<UpdateGeneralSpecialOfferDto> GetByIdGeneralSpecialOfferAsync(string id);
    }
}
