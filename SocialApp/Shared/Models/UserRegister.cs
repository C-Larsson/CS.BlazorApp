using SocialApp.Shared.DataAnnotations;
using System.ComponentModel.DataAnnotations;

#pragma warning disable 8618

namespace SocialApp.Shared.Models
{   
    /// <summary>
    /// User register request
    /// </summary>
    public class UserRegister
    {

        /// <summary>
        /// Email of the user
        /// </summary>
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Password of the user
        /// </summary>
        [Required, StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Repeat password of the user
        /// </summary>
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; } = string.Empty;


    }
}
