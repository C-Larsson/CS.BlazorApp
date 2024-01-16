using System.ComponentModel.DataAnnotations;

#pragma warning disable 8618

namespace SocialApp.Shared.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Stay signed in")]
        [Range(0, 1)]
        public bool StaySignedIn { get; set; }
    }
}
