using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Shared.Models.Tables
{
    public class Token
    {
        public int Id { get; set; } // int
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
        [Required]
        public int UserId { get; set; }
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow; // datetime
        public DateTime ExpiresAt { get; set; } // datetime
        public bool Revoked { get; set; } = false; // bit


    }
}
