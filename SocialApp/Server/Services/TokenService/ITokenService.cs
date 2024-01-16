using Microsoft.IdentityModel.Tokens;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.Token
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenService
    {

        ServiceResponse<string>  GenerateAccessToken(User user);
        ServiceResponse<string> GenerateRefreshToken(User user);
        ServiceResponse<string> GetAccessTokenFromHeader(string authorizationHeader);
        Task<ServiceResponse<bool>> UpdateToken(User user, string refreshToken);
        Task<ServiceResponse<bool>> SaveRefreshToken(int userId, string refreshToken);
        Task<ServiceResponse<bool>> ValidateRefreshToken(string refreshToken);


    }
}   
