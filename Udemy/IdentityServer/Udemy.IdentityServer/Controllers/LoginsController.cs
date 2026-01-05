using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.IdentityServer.Dtos;
using Udemy.IdentityServer.Models;

namespace Udemy.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginsController(SignInManager<ApplicationUser> userManager)
        {
            _signInManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password,false,false);
            if (result.Succeeded)
            {
                return Ok("Giriş Başarılı");
            }
            else
            {
                return Ok("Kullanıcı Adı ve ya Şifre Yanlış");
            }
        }
    }
}
