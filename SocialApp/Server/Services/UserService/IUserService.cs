using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.UserService
{
    public interface IUserService
    {

        Task<ServiceResponse<List<User>>> GetUsers();

        Task<ServiceResponse<UserSearchResult>> SearchUsers(string searchText, int page);

        Task<ServiceResponse<User>> UpdateUser(User user);

    }
}
