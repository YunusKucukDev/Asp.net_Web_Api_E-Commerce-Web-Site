using Udemy.DtoLayer.OrderDtos.OrderingDtos;

namespace Udemy.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
