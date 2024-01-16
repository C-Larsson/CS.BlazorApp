using SocialApp.Shared.Models;
using System.Net.Http.Json;

namespace SocialApp.Client.Services.ReservationService
{

    public class ReservationService : IReservationService
    {

        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public ReservationService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public string Message { get; set; } = "Loading reservations...";

       /* public Task<ServiceResponse<bool>> ConfirmPayment(List<Reservation> reservations)
        {
            var request = new PaymentRequest(reservations);
            return _http.PostAsJsonAsync<ServiceResponse<bool>>("api/payment/confirm", request);
        }*/

        public async Task<ServiceResponse<Reservation>> GetReservation(int eventId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Reservation>>($"api/reservation/{eventId}");
            return response;
        }

        public async Task GetReservations()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Reservation>>>($"api/reservation");
            if (result != null && result.Data != null)
                Reservations = result.Data;
        }

        public async  Task<string> MakePayment()
        {
            if (await IsUserAuthenticated())
            {
                var result = await _http.PostAsync("api/payment/checkout", null);
                var url = await result.Content.ReadAsStringAsync();
                return url;
            }
            else
            {
                return "login";
            }
        }

        public async Task<ServiceResponse<Reservation>> PlaceReservation(int eventId, int quantity)
        {
            var request = new ReservationRequest
            {
                EventId = eventId,
                TicketCount = quantity
            };
            var result = await _http.PostAsJsonAsync("/api/reservation/place/", request);
            var response = (await result.Content.ReadFromJsonAsync<ServiceResponse<Reservation>>());
            return response;
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

    }
    
}
