using Udemy.DtoLayer.UserDtos;

namespace Udemy.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentitySDervice
    {
        Task<List<ResultUserDto>> GetAllUserAsync();
    }
}
