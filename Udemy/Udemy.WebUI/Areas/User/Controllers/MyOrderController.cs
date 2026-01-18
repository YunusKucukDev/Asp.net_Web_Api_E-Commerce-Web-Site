using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.WebUI.Services.Interfaces;
using Udemy.WebUI.Services.OrderServices.OrderOrderingServices;

namespace Udemy.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {

        private readonly IOrderOrderingService _orderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOrderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values =await _orderingService.GetOrderingByUserId(user.Id);
            return View();
        }
    }
}
