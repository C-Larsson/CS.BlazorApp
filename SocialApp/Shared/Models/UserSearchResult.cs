
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Shared.Models
{
    public class UserSearchResult
    {
        public List<User> Users { get; set; } = new List<User>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
