
using Microsoft.EntityFrameworkCore;

namespace SocialApp.Server.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IEventService _eventService;

        public ReservationService(DataContext context, IAuthService authService, IEventService eventService) 
        { 
            _context = context;
            _authService = authService;
            _eventService = eventService;
        }

        public async Task<ServiceResponse<bool>> ConfirmPayment(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            var userId = user.Id;

            var pendingReservations = await _context.Reservations
                .Where(r => r.UserId == userId && r.PaymentStatus == PaymentStatus.Pending)
                .ToListAsync(); 

            if (pendingReservations.Count == 0) {                
                return new ServiceResponse<bool>
            {
                    Data = false,
                    Message = "No pending reservations found"
                };
            }

            foreach (var reservation in pendingReservations)
            {
                reservation.ReservationStatus = ReservationStatus.Confirmed;
                reservation.PaymentStatus = PaymentStatus.Paid;
                reservation.PaymentDate = DateTime.UtcNow;
                _context.Reservations.Update(reservation);
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Payment confirmed"
            };

        }

        public async Task<ServiceResponse<Reservation>> GetReservation(int eventId)
        {
            var response = new ServiceResponse<Reservation>();
            var userId = _authService.GetUserId();

            var reservation = await _context.Reservations
                .Include(x => x.Event).ThenInclude(e => e.Location)
                .FirstOrDefaultAsync(x => x.EventId == eventId && x.UserId == userId);

            if (reservation == null)
            {
                response.Success = false;
                response.Message = "Reservation not found";
                return response;
            }

            response.Data = reservation;
            return response;
        }

        public async Task<ServiceResponse<List<Reservation>>> GetReservations()
        {
            var userId = _authService.GetUserId();

            var response = new ServiceResponse<List<Reservation>>();
            try
            {
                // TODO: Filter out old reservations
                response.Data = await _context.Reservations
                    .Where(r => r.UserId == userId)
                    .Include(r => r.Event).ThenInclude(e => e.Images)
                    .Include(r => r.Event).ThenInclude(e => e.Location)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Reservation>>> GetUnpaidReservations()
        {
            var userId = _authService.GetUserId();
            var response = new ServiceResponse<List<Reservation>>();
            try
            {
                response.Data = await _context.Reservations
                    .Where(r => r.UserId == userId && r.PaymentStatus == PaymentStatus.Unpaid)
                    .Include(x => x.Event)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<Reservation>> PlaceReservation(int eventId, int quantity)
        {
            var response = new ServiceResponse<Reservation>();
            var userId = _authService.GetUserId();
            var event1 = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventId);
            
            if (event1 == null)
            {
                response.Success = false;
                response.Message = "The event was not found.";
                response.Data = null;
                return response;
            }

            var spotsLeft = event1.MaxAttendees - event1.AttendeeCount;
            if (spotsLeft < quantity)
            {
                response.Success = false;
                response.Message = "There are not enough spots left.";
                response.Data = null;
                return response;
            }

            Reservation reservation;
            if (event1.Price == 0)
            {
                reservation = new Reservation
                {
                    EventId = eventId,
                    UserId = userId,
                    AttendeeCount = quantity,
                    TotalPrice = 0,
                    CurrencyCode = null,
                    ReservationStatus = ReservationStatus.Confirmed,
                    PaymentStatus = PaymentStatus.NoFees
                };
            }
            else
            {
                reservation = new Reservation
                {
                    EventId = eventId,
                    UserId = userId,
                    AttendeeCount = quantity,
                    TotalPrice = event1.Price * quantity,
                    CurrencyCode = event1.CurrencyCode,
                    ReservationStatus = ReservationStatus.Pending,
                    PaymentStatus = PaymentStatus.Unpaid
                };
            }

            var result = await _eventService.UpdateAttendees(eventId, quantity);

            if (result.Success)
            {
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();
                response.Data = reservation;
                return response;
            }
            else
            {
                response.Success = false;
                response.Message = result.Message;
                await _context.DisposeAsync();
                response.Data = null;
                return response;
            }

        }

    }
}
