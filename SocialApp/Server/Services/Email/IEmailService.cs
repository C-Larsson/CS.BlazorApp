
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.Email
{
    /// <summary>
    /// Service for sending emails
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends a verification email to the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="resetToken"></param>
        /// <returns></returns>
        Task<ServiceResponse<bool>> SendPasswordResetEmail(User user, string resetToken);

    }
}
