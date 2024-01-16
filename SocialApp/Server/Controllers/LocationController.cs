using Microsoft.AspNetCore.Mvc;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Location>>>> GetLocations()
        {
            var result = await _locationService.GetLocations();
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Location>>>> GetEventSearchSuggestions(string searchText)
        {
            var result = await _locationService.GetLocationSearchSuggestions(searchText);
            return Ok(result);
        }

    }
}
