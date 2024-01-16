using Microsoft.AspNetCore.Mvc;

namespace SocialApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService) 
        { 
            _reservationService = reservationService;
        }


        [HttpPost("place")]
        public async Task<ActionResult<ServiceResponse<Reservation>>> PlaceReservation(ReservationRequest request)
        {
            var response = await _reservationService.PlaceReservation(request.EventId, request.TicketCount);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<ServiceResponse<Reservation>>> GetReservation(int eventId)
        {
            var response = await _reservationService.GetReservation(eventId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Reservation>>>> GetReservations()
        {
            var response = await _reservationService.GetReservations();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("unpaid")]
        public async Task<ActionResult<ServiceResponse<List<Reservation>>>> GetUnpaidReservations()
        {
            var response = await _reservationService.GetUnpaidReservations();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
