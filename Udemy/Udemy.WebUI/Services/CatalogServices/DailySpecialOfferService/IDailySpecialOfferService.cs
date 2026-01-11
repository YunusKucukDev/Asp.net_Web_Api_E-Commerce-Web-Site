using Udemy.DtoLayer.CatalogDtos.DailySpecialOfferDto;

namespace Udemy.WebUI.Services.CatalogServices.DailySpecialOfferService
{
    public interface IDailySpecialOfferService
    {
        Task<List<ResultDailySpecialOfferDto>> GetAllDailySpecialOfferAsync();
        Task CreateDailySpecialOfferAsync(CreateDailySpecialOfferDto createDailySpecialOfferDto);
        Task UpdateDailySpecialOfferAsync(UpdateDailySpecialOfferDto updateDailySpecialOfferDto);
        Task DeleteDailySpecialOfferAsync(string id);
        Task<UpdateDailySpecialOfferDto> GetByIdDailySpecialOfferAsync(string id);
    }
}
