using System.Net.Mail;
using System.Net;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.Email
{
    /// <summary>
    /// Service for sending emails
    /// </summary>
    public class EmailService : IEmailService
    {

        private readonly SmtpClient _client;

        /// <summary>
        /// Service for sending emails
        /// </summary>
        public EmailService()
        {
            _client = new SmtpClient("your-smtp-server.com");
            _client.UseDefaultCredentials = false;
            _client.Credentials = new NetworkCredential("username", "password");
        }

        public async Task<ServiceResponse<bool>> SendPasswordResetEmail(User user, string resetToken)
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("noreply@yourdomain.com");
            mailMessage.To.Add(user.Email);
            mailMessage.Body = $"Click this link to reset your password: https://yourapp.com/reset-password?token={resetToken}";
            mailMessage.Subject = "Password Reset";
            await _client.SendMailAsync(mailMessage);

            return new ServiceResponse<bool> {
                Data = true,
                Message = "Password reset email sent successfully!"
            };
      
        }


        /// <summary>
        /// Sends a verification email to the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="resetToken"></param>
        /// <returns></returns>
        public async Task SendPasswordResetEmailAsync(User user, string resetToken)
        {
   

        }


    }
}
