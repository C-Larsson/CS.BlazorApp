using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace SocialApp.IntegrationTest.Controllers
{
    public class ReservationController_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;


        public ReservationController_Tests(WebApplicationFactory<Program> factory)
        {
            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task PlaceReservation_FreeEvent_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var testEvent = await _testDataClient.GenerateFreeTestEventAsync();

            var reservationRequest = new ReservationRequest()
            { EventId = testEvent.Id, TicketCount = 1 };

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var serviceResponse = await _httpClient.PostAsJsonAsync<ReservationRequest>($"api/reservation/place", reservationRequest);
            Assert.Equal(System.Net.HttpStatusCode.OK, serviceResponse.StatusCode);

            var reservationResponse = await serviceResponse.Content.ReadFromJsonAsync<ServiceResponse<Reservation>>();
            var reservation = reservationResponse.Data;

            var eventFromDb = await _testDataClient.GetEventAsync(testEvent.Id);
           
            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteEventAsync(testEvent.Id);

            // Assert
            Assert.True(reservationResponse.Success);
            Assert.NotNull(reservation);
            Assert.Equal(ReservationStatus.Confirmed, reservation.ReservationStatus);
            Assert.Equal(PaymentStatus.NoFees, reservation.PaymentStatus);
            Assert.Equal(1, reservation.AttendeeCount);
            Assert.Equal(1, eventFromDb.AttendeeCount);
        }

        [Fact]
        public async Task PlaceReservation_10USDEvent_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var testEvent = await _testDataClient.GenerateUSDTestEventAsync();

            var reservationRequest = new ReservationRequest()
            { EventId = testEvent.Id, TicketCount = 5 };

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var serviceResponse = await _httpClient.PostAsJsonAsync<ReservationRequest>($"api/reservation/place", reservationRequest);
            Assert.Equal(System.Net.HttpStatusCode.OK, serviceResponse.StatusCode);

            var reservationResponse = await serviceResponse.Content.ReadFromJsonAsync<ServiceResponse<Reservation>>();
            var reservation = reservationResponse.Data;

            var eventFromDb = await _testDataClient.GetEventAsync(testEvent.Id);
            
            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteEventAsync(testEvent.Id);

            // Assert
            Assert.True(reservationResponse.Success);
            Assert.NotNull(reservation);
            Assert.Equal(ReservationStatus.Pending, reservation.ReservationStatus);
            Assert.Equal(PaymentStatus.Unpaid, reservation.PaymentStatus);
            Assert.Equal(5, reservation.AttendeeCount);
            Assert.Equal(5, eventFromDb.AttendeeCount);
        }

        [Fact]
        public async Task PlaceReservation_EventFull_NotOK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var testEvent = await _testDataClient.GenerateFreeTestEventAsync();

            var reservationRequest = new ReservationRequest()
            { EventId = testEvent.Id, TicketCount = 50 };

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var serviceResponse = await _httpClient.PostAsJsonAsync<ReservationRequest>($"api/reservation/place", reservationRequest);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, serviceResponse.StatusCode);

            var reservationResponse = await serviceResponse.Content.ReadFromJsonAsync<ServiceResponse<Reservation>>();
            var reservation = reservationResponse.Data;

            var eventFromDb = await _testDataClient.GetEventAsync(testEvent.Id);

            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteEventAsync(testEvent.Id);

            // Assert
            Assert.False(reservationResponse.Success);
            Assert.Null(reservation);
            Assert.Equal(0, eventFromDb.AttendeeCount);
        }



    }
}
