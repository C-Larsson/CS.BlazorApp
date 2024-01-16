using Microsoft.EntityFrameworkCore;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.ProfileService
{
    public class ProfileService : IProfileService
    {

        public readonly DataContext _context;
        public readonly IAuthService _authService;

        public ProfileService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }   

        public async Task<ServiceResponse<Profile>> AddProfile(Profile profile)
        {
            var userId = _authService.GetUserId();
 
            var user = await _context.Users
                .Include(u => u.Profile)
                .ThenInclude(p => p.Image)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return new ServiceResponse<Profile>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            user.Profile = profile;
            await _context.SaveChangesAsync();
            return new ServiceResponse<Profile>
            {
                Data = profile
            };
        }

        public Task DeleteProfile(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Profile>> GetProfile()
        {
            var userId = _authService.GetUserId();
            var user = await _context.Users
                .Include(u => u.Profile)
                .ThenInclude(p => p.Image)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null || user.Profile == null)
            {
                return new ServiceResponse<Profile>
                {
                    Success = false,
                    Message = "User/Profile not found."
                };
            }
            return new ServiceResponse<Profile>
            {
                Data = user.Profile
            };
        }

        public async Task<ServiceResponse<Profile>> UpdateProfile(Profile profile)
        {
       
            var userId = _authService.GetUserId();
            
            var user = await _context.Users
                .Include(u => u.Profile)
                .ThenInclude(p => p.Image)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null || user.Profile == null)
            {
                return new ServiceResponse<Profile>
                {
                    Success = false,
                    Message = "User/Profile not found."
                };
            }

            // TODO: Could be optimized to only delete if the image is being changed.
            if (user.Profile.Image != null)
            {
                _context.Images.Remove(user.Profile.Image);
            }
            user.Profile.Name = profile.Name;
            user.Profile.Bio = profile.Bio;
            user.Profile.Image = profile.Image;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Profile>
            {
                Data = user.Profile
            };
        }
    }
}
