using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.ProfileService
{
    public interface IProfileService
    {

        Task<ServiceResponse<Profile>> AddProfile(Profile profile);
        Task<ServiceResponse<Profile>> UpdateProfile(Profile profile);
        Task<ServiceResponse<Profile>> GetProfile();
        
        Task DeleteProfile(int id);
    }
}
