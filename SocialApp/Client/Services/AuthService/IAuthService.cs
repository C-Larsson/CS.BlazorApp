using SocialApp.Shared.Models;

namespace SocialApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin userLogin);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword userChangePassword);
        Task<bool> IsUserAuthenticated();
        Task<string> GetUserName();
    }
}
