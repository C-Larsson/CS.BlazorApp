namespace SocialApp.Server.Services.Token
{

    /// <summary>
    /// 
    /// </summary>
    public interface ITokenCleanupService
    {
        /// <summary>
        /// Cleans up expired tokens
        /// </summary>
        /// <returns></returns>
        Task CleanupExpiredTokensAsync();

    }
}
