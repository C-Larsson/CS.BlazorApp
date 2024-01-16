using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public AuthService(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILogger logger)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
          
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect password.";
            }
            else
            {
                string token = CreateToken(user);
                response.Data = token;
            }   
            return response;
        }

        public async Task<ServiceResponse<string>> LoginWithRefreshToken(string email, string password)
        {
            var response = await Login(email, password);

            if (response.Success) {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
                var refreshToken = GenerateRefreshToken();
                SetRefreshTokenCookie(refreshToken);
                user.RefreshToken = refreshToken.Token;
                user.TokenCreated = refreshToken.Created;
                user.TokenExpires = refreshToken.Expires;
                await _context.SaveChangesAsync();
            }
            return response;

        }

        public async Task<ServiceResponse<string>> RefreshToken(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == token);

            if (!token.Equals(user.RefreshToken))
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Invalid token."
                };
            }
            else if (DateTime.UtcNow > user.TokenExpires)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Token expired."
                };
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                SetRefreshTokenCookie(refreshToken);
                user.RefreshToken = refreshToken.Token;
                user.TokenCreated = refreshToken.Created;
                user.TokenExpires = refreshToken.Expires;
                await _context.SaveChangesAsync();
                return new ServiceResponse<string>
                {
                    Data = CreateToken(user)
                };
            }   
        }


        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return new ServiceResponse<int> { 
                Data = user.Id, 
                Message = "Registration successful!" 
            };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

  

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            else
            {
                CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Message = "Password changed successfully."
                };
            }
        }


        public async Task<ServiceResponse<bool>> UpdateLastActive(string email, DateTime loginDate)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
           
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            
            user.LastActive = loginDate;
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Last active date updated successfully."
            };
        }


        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users
                .Include(u => u.Profile)
                .ThenInclude(p => p.Image)
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Email.Equals(email));

            return user;
        }

        public Task<ServiceResponse<User>> GetUserByPasswordResetToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> GeneratePasswordResetToken(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<User>> GetUser()
        {
            var userId = GetUserId();
            var user = await _context.Users
                .Include(u => u.Profile)
                .ThenInclude(p => p.Image)
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return new ServiceResponse<User>
                {
                    Success = false,
                    Message = "User not found."
                };
            }   
            return new ServiceResponse<User>
            {
                Data = user,
                Message = "User found."
            };  
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512()) // HMACSHA512 is a disposable class
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var tokenSecret = _configuration.GetSection("AppSettings:Token").Value;

            var key = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(tokenSecret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private RefreshToken GenerateRefreshToken()
        {
            // generate a random string with 64 characters
            const string allowed = "ABCDEFGHIJKLMONOPQRSTUVWXYZabcdefghijklmonopqrstuvwxyz0123456789";
            var chars = new char[64];
            var rd = new Random();
            for ( int i = 0; i < 64; i++ )
            {
                chars[i] = allowed[rd.Next(0, allowed.Length)];
            }
            var token = new string(chars);

            var refreshToken = new RefreshToken
            {
                Token = token,
                Expires = DateTime.UtcNow.AddDays(90),
            };
            return refreshToken;
        }

        private void SetRefreshTokenCookie(RefreshToken token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = token.Expires,
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", token.Token, cookieOptions);
        }

    
    }
}
