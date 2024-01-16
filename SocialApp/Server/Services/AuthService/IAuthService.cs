
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.AuthService
{
    public interface IAuthService
    {
        int GetUserId();
        string GetUserEmail();
        
        Task<bool> UserExists(string email);
        Task<ServiceResponse<User>> GetUser();
        Task<User> GetUserByEmail(string email);

        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<string>> LoginWithRefreshToken(string email, string password);
        Task<ServiceResponse<string>> RefreshToken(string token);
        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
        Task<ServiceResponse<User>> GetUserByPasswordResetToken(string token);
        Task<ServiceResponse<bool>> UpdateLastActive(string email, DateTime loginDate);
        Task<ServiceResponse<string>> GeneratePasswordResetToken(User user);



   
 
        
        

    }
}
