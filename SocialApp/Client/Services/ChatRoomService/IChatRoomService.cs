
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Client.Services.ChatRoomService
{
    public interface IChatRoomService
    {

        List<EventMessage> ChatMessages { get; set; }
        event Action ChatMessagesChanged;


        Task GetMessages(int eventId);

        Task<EventMessage> SaveMessage(string eventId, string message);





    }
}
