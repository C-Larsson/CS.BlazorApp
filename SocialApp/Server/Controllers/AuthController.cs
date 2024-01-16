using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Shared.Models.Tables;
using System.Security.Claims;


namespace SocialApp.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response = await _authService.Register(
                new User { Email = request.Email }, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = new ServiceResponse<string>();
            if (request.StaySignedIn)
            {
                response = await _authService.LoginWithRefreshToken(request.Email, request.Password);
            }
            else
            {
                response = await _authService.Login(request.Email, request.Password);
            }

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<ServiceResponse<string>>> RefreshToken(RefreshTokenRequest request)
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _authService.RefreshToken(refreshToken);
            if (!response.Success)
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }


        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _authService.ChangePassword(int.Parse(userId), newPassword);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpGet, Authorize]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser()
        {
            var response = await _authService.GetUser();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        
    }


}
