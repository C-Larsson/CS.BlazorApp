namespace SocialApp.Shared.Models

#pragma warning disable 8618

{
    /// <summary>
    /// 
    /// </summary>
    public class TokenData
    {
        /// <summary>
        /// An access token
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// A refresh token
        /// </summary>
        public string? RefreshToken { get; set; } = string.Empty;

    }
}
