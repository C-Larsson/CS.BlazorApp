using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialApp.Shared.Models.Tables;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialApp.Server.Services.Token
{
    /// <summary>
    /// Service for handling tokens
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        private readonly ILogger<TokenService> _logger;

        /// <summary>
        /// 
        /// </summary>
        public TokenService(IConfiguration config, DataContext context, ILogger<TokenService> logger)
        {
            _config = config;
            _context = context;
            _logger = logger;
        }



        /// <summary>
        /// Generates the access token for the user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ServiceResponse<string> GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("SecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                // You can add more claims if needed
            }),
                Expires = DateTime.UtcNow.AddHours(24), // Token expires after 24 hours
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new ServiceResponse<string>
            {
                Data = tokenHandler.WriteToken(token)
            };
        }

        /// <summary>
        /// Generates the refresh token for the user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ServiceResponse<string> GenerateRefreshToken(User user)
        {
            // Similar to GenerateAccessToken, but with longer expiry time.
            // Refresh tokens can also be stored in the database against the user's record
            // for added security and to invalidate them if needed.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("SecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                // You can add more claims if needed
            }),
                Expires = DateTime.UtcNow.AddDays(90), // Token expires after 90 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new ServiceResponse<string>
            {
                Data = tokenHandler.WriteToken(token)
            };
        }

        /// <summary>
        /// Gets the access token from the authorization header.
        /// </summary>
        /// <param name="authorizationHeader"></param>
        /// <returns></returns>
        public ServiceResponse<string> GetAccessTokenFromHeader(string authorizationHeader)
        {
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Authorization header is missing."
                };
            }
            var token = authorizationHeader.Split(' ')[1];
            return new ServiceResponse<string> { Data = token };
        }


        /// <summary>
        /// Saves the refresh token in the database.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> SaveRefreshToken(int userId, string refreshToken)
        {
            var token = new Shared.Models.Tables.Token
            {
                UserId = userId,
                RefreshToken = refreshToken,
                IssuedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(90),
                Revoked = false
            };

            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Refresh token saved successfully."
            };
        }

        public async Task<ServiceResponse<bool>> DeleteRefreshToken(int userId)
        {
            // delete the refresh token from the database
            var token = await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == userId);
            if (token != null)
            {
                _context.Tokens.Remove(token);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool> { Data = true };
            }
            else
            {
                return new ServiceResponse<bool> { Success = false, Data = false };
            }
        }


        public async Task<ServiceResponse<bool>> ValidateRefreshToken(string refreshToken) { 
        
            var token = await _context.Tokens.FirstOrDefaultAsync(t => t.RefreshToken == refreshToken);

            var validationStatus = ValidateToken(token);

            if (validationStatus)
            {
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Message = "Token is valid."
                };
            }
            else
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Token is invalid."
                };
            }   

        }

        public async Task<ServiceResponse<bool>> UpdateToken(User user, string refreshToken)
        {
            var userToken = await _context.Tokens.FirstOrDefaultAsync(ut => ut.UserId == user.Id);

            if (userToken != null)
            {
                userToken.RefreshToken = refreshToken;
                userToken.ExpiresAt = DateTime.UtcNow.AddDays(90);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Token updated for user {user.Email}");

                return new ServiceResponse<bool>
                {
                    Data = true,
                    Message = "Token updated successfully."
                };
            }
            else
            {
                _logger.LogError($"No token found for user {user.Email}");
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "No token found."
                };
            }
        }
        
        private bool ValidateToken(Shared.Models.Tables.Token? token)
        {
            if (token == null)
            {
                return false;
            }
            return (token.ExpiresAt > DateTime.UtcNow && token.Revoked == false);
        }

    }
}
