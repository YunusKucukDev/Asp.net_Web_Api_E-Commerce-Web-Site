using Udemy.DtoLayer.IdentityDtos.LoginDtos;

namespace Udemy.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto dto);
    }
}
