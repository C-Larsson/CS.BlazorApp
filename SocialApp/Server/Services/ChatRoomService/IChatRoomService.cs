using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.ChatRoomService
{
    public interface IChatRoomService
    {

        Task<ServiceResponse<List<EventMessage>>> GetEventMessages(int eventId, int count);
        Task<ServiceResponse<EventMessage>> AddMessage(int eventId, string message);
    }
}
