using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.IdentityDtos.RegisterDtos;

namespace Udemy.WebUI.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index( CreateRegisterDto dto)
        {
            if (dto.Password == dto.ConfirmPassword)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(dto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:5001/api/Registers", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Login");
                }
            }
            return View();
        }
    }
}
