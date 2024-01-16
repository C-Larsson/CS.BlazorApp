using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;


namespace SocialApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();

        
        
        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            string eventId = Context.GetHttpContext().Request.Query["event"];
            Users.Add(Context.ConnectionId, username);
            await SendMessageToRoom(eventId, username, $"{username} has joined the chat");
            await base.OnConnectedAsync(); 
        }

        /*public async Task SendMessage(string user, string message)
        {
            // Send message to all
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }*/

        public async Task SendMessageToRoom(string eventId, string user, string message)
        {
            // Send message to group
            await Clients.Group(eventId).SendAsync("ReceiveMessage", user, message);
        }


        public async Task JoinRoom(string eventId)
        {
            string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            await Groups.AddToGroupAsync(Context.ConnectionId, eventId);
            //await Clients.Group(eventId).SendAsync("Notify", $"{username} joined room {eventId}.");
            await Clients.Group(eventId).SendAsync("ReceiveMessage", username, " has joined.");
        }

        public async Task LeaveRoom(string eventId)
        {
            string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            //await Clients.Group(eventId).SendAsync("Notify", $"{username} left!"); 
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, eventId);
            await Clients.Group(eventId).SendAsync("ReceiveMessage", username, " has left.");
        }


    }
}
