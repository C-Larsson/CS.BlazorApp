

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Shared.Models.Tables
{

    public enum Role
    {
        Admin,
        Member
    }

    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public string RefreshToken { get; set; } = string.Empty;    
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }

        public virtual Profile? Profile { get; set; }

        public int? AddressId { get; set; } = null;
        public virtual Address? Address { get; set; }

        public int? LocationId { get; set; }
        public virtual Location? Location { get; set; }

        public List<Reservation>? Reservations { get; set; } = null;

        [JsonIgnore]
        public virtual List<EventMessage> EventMessages { get; set; } = new List<EventMessage>();

        public Role Role { get; set; } = Role.Member;

        public bool Blocked { get; set; } = false;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
    }
}
