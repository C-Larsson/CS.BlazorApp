using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Json;

namespace SocialApp.Client.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;

        public ProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Profile Profile { get; set; } = null;

        public event Action OnChange;

        public async Task AddProfile(Profile profile)
        {
            var result = await _httpClient.PostAsJsonAsync("api/profile", profile);
            Profile = (await result.Content.ReadFromJsonAsync<ServiceResponse<Profile>>()).Data;
            OnChange.Invoke();
        }

        public Profile CreateNewProfile()
        {
            var newProfile = new Profile() { IsNew = true, Editing = true };
            Profile = newProfile;
            OnChange.Invoke();
            return newProfile;
        }

        public async Task GetProfile()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Profile>>("api/profile");
            if (result != null && result.Data != null)
                Profile = result.Data;
        }

        public async Task UpdateProfile(Profile profile)
        {
            var response = await _httpClient.PutAsJsonAsync("api/profile", profile);
            Profile = (await response.Content.ReadFromJsonAsync<ServiceResponse<Profile>>()).Data;
            OnChange.Invoke();
        }


    }
}
