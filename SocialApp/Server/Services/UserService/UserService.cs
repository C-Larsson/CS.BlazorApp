using Microsoft.EntityFrameworkCore;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.UserService
{
    public class UserService : IUserService
    {

        public readonly DataContext _context;
        
        public UserService(DataContext context)
        {
            _context = context;
        }   

        public async Task<ServiceResponse<List<User>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Profile)
                .ThenInclude(p => p.Image)
                .ToListAsync();
            return new ServiceResponse<List<User>>
            {
                Data = users
            };
        }

        public async Task<ServiceResponse<UserSearchResult>> SearchUsers(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindUsersBySearchText(searchText)).Count / pageResults);
            var users = await _context.Users
                                .Include(u => u.Profile)
                                .ThenInclude(p => p.Image)
                                .Where(e => e.Email.ToLower().Contains(searchText.ToLower()) ||
                                   (e.Profile != null && e.Profile.Name.ToLower().Contains(searchText.ToLower())))
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<UserSearchResult>
            {
                Data = new UserSearchResult
                {
                    Users = users,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            return response;    
        }

        public async Task<ServiceResponse<User>> UpdateUser(User user)
        {
            var dbUser = await _context.Users
             .Include(u => u.Profile)
             .ThenInclude(p => p.Image)
             .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (dbUser == null)
            {
                return new ServiceResponse<User>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            dbUser.Role = user.Role;
            dbUser.Blocked = user.Blocked;
            dbUser.Deleted = user.Deleted;

            await _context.SaveChangesAsync();
            return new ServiceResponse<User> { Data = dbUser };
        }


        /// ///////////////////////////////

        private async Task<List<User>> FindUsersBySearchText(string searchText)
        {
            return await _context.Users
                                .Include(u => u.Profile)
                                .ThenInclude(p => p.Image)
                                .Where(e => e.Email.ToLower().Contains(searchText.ToLower()) ||
                                    (e.Profile != null && e.Profile.Name.ToLower().Contains(searchText.ToLower())))
                                .ToListAsync();
        }
    }
}
