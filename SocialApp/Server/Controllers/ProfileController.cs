using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        public readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<ServiceResponse<Profile>>> AddUserProfile([FromBody] Profile profile)
        {
            var result = await _profileService.AddProfile(profile);
            return Ok(result);
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<ServiceResponse<Profile>>> GetUserProfile()
        {
            var result = await _profileService.GetProfile();
            return Ok(result);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<Profile>>> UpdateUserProfile([FromBody] Profile profile)
        {
            var result = await _profileService.UpdateProfile(profile);
            return Ok(result);
        }

    }
}
