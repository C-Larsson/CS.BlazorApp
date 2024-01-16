using Microsoft.EntityFrameworkCore;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.ChatRoomService
{
    public class ChatRoomService : IChatRoomService
    {

        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public ChatRoomService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<EventMessage>>> GetEventMessages(int eventId, int count)
        {

            var messages = await _context.EventMessages
                .Where(m => m.EventId == eventId)
                .Include(m => m.Sender)
                .OrderByDescending(m => m.SentAt)
                .Take(count)
                .ToListAsync();
           
            messages.Reverse(); // Reverse the list so that the newest messages are at the bottom

            if (messages == null || messages.Count == 0)
            {
                return new ServiceResponse<List<EventMessage>>
                {
                    Data = new List<EventMessage>(),
                    Message = "Chat room not found",
                    Success = false
                };
            }

            return new ServiceResponse<List<EventMessage>>
            {
                Data = messages
            };
        }

        public async Task<ServiceResponse<EventMessage>> AddMessage(int eventId, string message)
        {
            var userId = _authService.GetUserId();
            var eventMessage = new EventMessage
            {
                EventId = eventId,
                Content = message,
                SenderId = userId,
            };

            var result = await _context.EventMessages.AddAsync(eventMessage);
            await _context.SaveChangesAsync();

            return new ServiceResponse<EventMessage>
            {
                Data = result.Entity,
                Message = "Chat message saved.",
                Success = true
            };
        }
    }
}
