using SocialApp.Shared.Models.Tables;

namespace SocialApp.Client.Services.ProfileService
{
    public interface IProfileService
    {
        event Action OnChange;
        Profile Profile { get; set; }

        Task GetProfile();

        Profile CreateNewProfile();
        Task AddProfile(Profile profile);
        Task UpdateProfile(Profile profile);


    }
}
