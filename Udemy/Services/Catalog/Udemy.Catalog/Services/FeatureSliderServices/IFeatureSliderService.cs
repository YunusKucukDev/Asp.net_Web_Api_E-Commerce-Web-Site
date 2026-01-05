using Udemy.Catalog.DTOs.FeatureSliderDtos;

namespace Udemy.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {

        Task<List<ResultFeatureSliderDto>> GetAllFeatureslider();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
        

    }
}
