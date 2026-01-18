using Microsoft.AspNetCore.Mvc;
using Udemy.WebUI.Services.CargoServices.CargocustomerServices;
using Udemy.WebUI.Services.UserIdentityServices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly IUserIdentitySDervice _userIdentitySDService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserIdentitySDervice userIdentitySDService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentitySDService = userIdentitySDService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _userIdentitySDService.GetAllUserAsync();
            return View(values);
        }

        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var values = await _cargoCustomerService.GetByIdCargoCustomerAsync(id);
            return View(values);
        }

    }
}
