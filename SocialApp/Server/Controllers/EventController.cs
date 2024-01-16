using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventService _eventService;


        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("single"), Authorize]
        public async Task<ActionResult<ServiceResponse<Event>>> CreateEvent(Event event1)
        {
            var response = await _eventService.CreateEvent(event1);
            return Ok(response);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<Event>>> UpdateEvent(Event event1)
        {
            var result = await _eventService.UpdateEvent(event1);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Event>>>> GetAdminEvents()
        {
            var result = await _eventService.GetAdminEvents();
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Event>>>> GetEventsByCategory(string categoryUrl)
        {
            var result = new ServiceResponse<List<Event>>();
            if (categoryUrl.Equals("featured")) {
                result = await _eventService.GetFeaturedEvents();
            }
            else {
                result = await _eventService.GetEventsByCategory(categoryUrl);
            }
            return Ok(result);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Event>>>> GetFeaturedEvents()
        {
            var result = await _eventService.GetFeaturedEvents();
            return Ok(result);
        }

        [HttpGet("my"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<Event>>>> GetMyEvents()
        {
            var result = await _eventService.GetMyEvents();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Event>>> GetEvent(int id)
        {
            var result = await _eventService.GetEvent(id);
            return Ok(result);
        }


        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<EventSearchResult>>> SearchEvents(string searchText, int page = 1)
        {
            var result = await _eventService.SearchEvents(searchText, page);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Event>>>> GetEventSearchSuggestions(string searchText)
        {
            var result = await _eventService.GetEventSearchSuggestions(searchText);
            return Ok(result);
        }


    }
}
