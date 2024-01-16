using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialApp.Shared.Models.Tables
{
    public class Profile
    {

        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Bio { get; set; } = null;

        public int? ImageId { get; set; }
        public virtual Image? Image { get; set; }

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;

        // Interests
        //public ICollection<string>? Interests { get; set; } = null;
    }
}
