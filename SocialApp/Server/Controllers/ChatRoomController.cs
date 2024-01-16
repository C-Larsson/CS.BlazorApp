using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocialApp.Server.Hubs;

using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {

        private readonly IChatRoomService _chatRoomService;
        private readonly IHubContext<ChatHub> _chatHubContext;

        public ChatRoomController(IChatRoomService chatRoomService, IHubContext<ChatHub> chatHubContext)
        {
            _chatRoomService = chatRoomService;
            _chatHubContext = chatHubContext;
        }


        [HttpGet("{eventId}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<EventMessage>>>> GetEventMessages(int eventId)
        {
            var result = await _chatRoomService.GetEventMessages(eventId, 50);
            return Ok(result);
        }

        [HttpPost("{eventId}/message"), Authorize]
        public async Task<ActionResult<ServiceResponse<EventMessage>>> PostChatMessage(PostMessage request)
        {
            var result = await _chatRoomService.AddMessage(request.EventId, request.Message);
            await _chatHubContext.Clients.Group(request.EventId.ToString()).SendAsync("ReceiveMessage", result.Data);
            return Ok(result);
        }

    }
}
