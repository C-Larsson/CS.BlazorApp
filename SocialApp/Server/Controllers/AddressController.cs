using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<ServiceResponse<Address>>> AddUserAddress([FromBody] Address address)
        {
            var result = await _addressService.AddUserAddress(address);
            return Ok(result);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<Address>>> UpdateUserAddress([FromBody] Address address)
        {
            var result = await _addressService.UpdateUserAddress(address);
            return Ok(result);
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<ServiceResponse<Address>>> GetUserAddress()
        {
            var result = await _addressService.GetUserAddress();
            return Ok(result);
        }

    }
}
