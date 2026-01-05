using Udemy.Catalog.DTOs.DailySpecialOfferDtos;

namespace Udemy.Catalog.Services.DailyspecialOfferService
{
    public interface IDailySpecialOfferService
    {
        Task<List<ResultDailySpecialOfferDto>> GetAllDailySpecialOfferAsync();
        Task CreateDailySpecialOfferAsync(CreateDailySpecialOfferDto createDailySpecialOfferDto);
        Task UpdateDailySpecialOfferAsync(UpdateDailySpecialOfferDto updateDailySpecialOfferDto);
        Task DeleteDailySpecialOfferAsync(string id);
        Task<GetByIdDailySpecialOfferDto> GetByIdDailySpecialOfferAsync(string id);
    }
}
