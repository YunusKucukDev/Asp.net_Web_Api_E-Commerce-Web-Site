using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.DtoLayer.OrderDtos.OrderAddressDtos;
using Udemy.WebUI.Services.Interfaces;
using Udemy.WebUI.Services.OrderServices.OrderAddressServices;

namespace Udemy.WebUI.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderAddressService _orderAddresService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderAddresService, IUserService userService)
        {
            _orderAddresService = orderAddresService;
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDtos createOrderAddressDtos)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDtos.UserId = values.Id;
            createOrderAddressDtos.Description = "aa";

            await _orderAddresService.CreateOrderAddressAsync(createOrderAddressDtos);
            return RedirectToAction("Index","Payment");
        }
    }
}
