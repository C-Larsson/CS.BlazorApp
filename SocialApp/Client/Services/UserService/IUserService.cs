
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Client.Services.UserService
{
    public interface IUserService
    {

        event Action OnChange;
        List<User>  Users { get; set; }

        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }

        Task GetUsers();
        Task SearchUsers(string searchText, int page);
        Task UpdateUser(User request);


    }
}
