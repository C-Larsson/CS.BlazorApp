using SocialApp.Shared.Models;

namespace SocialApp.Client.Services.ReservationService
{
    public interface IReservationService
    {

        List<Reservation> Reservations { get; set; }

        string Message { get; set; }

        Task<string> MakePayment();
        Task GetReservations();

        Task<ServiceResponse<Reservation>> PlaceReservation(int eventId, int quantity);

        Task<ServiceResponse<Reservation>> GetReservation(int eventI);
      
        //Task<ServiceResponse<List<Reservation>>> GetUnpaidReservations(int? userId = null);

        //Task<ServiceResponse<List<Reservation>>> ConfirmPayment(List<Reservation> reservations);


    }
}
