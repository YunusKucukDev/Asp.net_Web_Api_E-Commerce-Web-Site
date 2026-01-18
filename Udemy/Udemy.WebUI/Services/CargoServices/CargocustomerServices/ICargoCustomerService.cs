using Udemy.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace Udemy.WebUI.Services.CargoServices.CargocustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerById> GetByIdCargoCustomerAsync(string id);
    }
}
