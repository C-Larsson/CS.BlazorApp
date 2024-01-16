
using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Json;

namespace SocialApp.Client.Services.ChatRoomService
{
    public class ChatRoomService : IChatRoomService
    {

        private readonly HttpClient _http;


        public ChatRoomService(HttpClient http)
        {
            _http = http;
        }

        public List<EventMessage> ChatMessages { get; set; }
        public event Action ChatMessagesChanged;

        public async Task GetMessages(int eventId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EventMessage>>>($"api/chatroom/{eventId}");
            if (result != null && result.Data != null)
            {
                ChatMessages = result.Data;
                ChatMessagesChanged?.Invoke();
            }
        }

        public async Task<EventMessage> SaveMessage(string eventId, string message)
        {
            var request = new PostMessage { EventId = int.Parse(eventId), Message = message };
            var response = await _http.PostAsJsonAsync($"api/chatroom/{eventId}/message", request);
            var result = (await response.Content.ReadFromJsonAsync<ServiceResponse<EventMessage>>());
           
            if (result.Success)
            {
                ChatMessages.Add(result.Data);
            }
            return result.Data;
        }
    }
}
