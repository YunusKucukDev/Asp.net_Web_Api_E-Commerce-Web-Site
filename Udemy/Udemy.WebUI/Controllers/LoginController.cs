using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Udemy.DtoLayer.IdentityDtos.LoginDtos;
using Udemy.WebUI.Models;
using Udemy.WebUI.Services.Interfaces;

namespace Udemy.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginservice;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginservice, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginservice = loginservice;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto dto)
        {
            return View();
        }



        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto dto)
        {
            dto.Username = "yunuskck35";
            dto.Password = "Aa1234.";
            await _identityService.SignIn(dto);
            return RedirectToAction("Index", "User");
        }

    }
}
