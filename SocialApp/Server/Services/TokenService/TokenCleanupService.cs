using SocialApp.Server.Data;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SocialApp.Server.Services.Token
{
    /// <summary>
    /// A service for cleaning up expired tokens
    /// </summary>
    public class TokenCleanupService : ITokenCleanupService
    {
        private readonly Timer _timer;
        private readonly ILogger<TokenCleanupService> _logger;
        private readonly DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public TokenCleanupService(DataContext context, ILogger<TokenCleanupService> logger)
        {
            // Set up a timer that triggers every day
            _timer = new Timer(24 * 60 * 60 * 1000); // Interval is in milliseconds
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();

            _context = context;
            _logger = logger;

        }

        private async void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            await CleanupExpiredTokensAsync();
        }

        /// <summary>
        /// Removes all expired tokens from the database
        /// </summary>
        /// <returns></returns>
        public async Task CleanupExpiredTokensAsync()
        {
            // Get the current time
            var now = DateTime.UtcNow;

            // Find all users with expired tokens
            /*
            var users = await _context.Users.Where(u => u.PasswordResetTokenExpiration < now).ToListAsync();

            // Remove the tokens
            foreach (var user in users)
            {
                user.PasswordResetToken = null;
                user.PasswordResetTokenExpiration = null;
            }

            // Save changes to the database
            //await _context.UpdateAsync(users);
            _logger.LogInformation($"Removed {users.Count} expired tokens");
            */
        }
    }
}

