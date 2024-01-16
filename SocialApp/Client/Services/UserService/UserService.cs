using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;


namespace SocialApp.Client.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;    

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<User> Users { get; set; } = new List<User>();
        public string Message { get; set; } = "Loading users...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action OnChange;

        public async Task GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<User>>>("/api/user/admin");
            if (result != null && result.Data != null)
                Users = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Users.Count == 0)
                Message = "No users found";
        }

        public async Task SearchUsers(string searchText, int page)
        {
            LastSearchText = searchText;
            var result = await _httpClient
                 .GetFromJsonAsync<ServiceResponse<UserSearchResult>>($"api/user/admin/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Users = result.Data.Users;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Users.Count == 0) Message = "No users found.";
            OnChange?.Invoke();
        }

        public async Task UpdateUser(User request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/user/admin", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<User>>();
            await GetUsers();
            OnChange.Invoke();
        }
    }
}
