using System.ComponentModel.DataAnnotations;

#pragma warning disable 8618

namespace SocialApp.Shared.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string RefreshToken { get; set; }

    }
}
