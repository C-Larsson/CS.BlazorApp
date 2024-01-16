namespace SocialApp.Server.Services.ReservationService
{
    public interface IReservationService
    {
        Task<ServiceResponse<Reservation>> PlaceReservation(int eventId, int quantity);

        Task<ServiceResponse<bool>> ConfirmPayment(string email);

        Task<ServiceResponse<Reservation>> GetReservation(int eventId);
        Task<ServiceResponse<List<Reservation>>> GetReservations();
        Task<ServiceResponse<List<Reservation>>> GetUnpaidReservations();

 
    }
}
