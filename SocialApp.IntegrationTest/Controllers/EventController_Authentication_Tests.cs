using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace SocialApp.IntegrationTest.Controllers
{
    public class EventController_Authentication_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;

        public EventController_Authentication_Tests(WebApplicationFactory<Program> factory)
        {
            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task CreateEvent_InvalidToken_Unauthorized()
        {
            // Prepare
            var randomAccessToken = "fyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMDAwMDAwMDk3IiwibmJmIjoxNjg3NzYxNjczLCJleHAiOjF2ODc4NDgwNzMsImlhdCI6MTY4Nzc2MTY3M30.4kWe5eLju_TuVsFZPG4tHqjsEblkEuq4Ne6JNyjUAcE";

            var singleEvent = new Event()
            {
                Title = "Test Event",
                CategoryId = 1,
                LocationId = 1,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
            };

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", randomAccessToken);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Event>("/api/event/single/", singleEvent);
 
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);
            Assert.Equal("Unauthorized", httpResponseMessage.ReasonPhrase);
        }


        [Fact]
        public async Task CreateEvent_NoLogin_Unauthorized()
        {
            // Prepare
            var singleEvent = new Event()
            {
                Title = "Test Event",
                CategoryId = 1,
                LocationId = 2,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
            };

            // Act
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Event>("/api/event/single/", singleEvent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);
            Assert.Equal("Unauthorized", httpResponseMessage.ReasonPhrase);
        }

        [Fact]
        public async Task UpdateEvent_NoLogin_Unauthorized()
        {
            // Prepare
            var singleEvent = new Event()
            {
                Title = "Test Event",
                CategoryId = 1,
                LocationId = 2,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
            };

            // Act
            var httpResponseMessage = await _httpClient.PutAsJsonAsync<Event>("/api/event/", singleEvent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);
            Assert.Equal("Unauthorized", httpResponseMessage.ReasonPhrase);
        }

        [Fact]
        public async Task DeleteEvent_NoLogin_Unauthorized()
        {
            // Act
            var httpResponseMessage = await _httpClient.DeleteAsync($"api/event/1");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);
            Assert.Equal("Unauthorized", httpResponseMessage.ReasonPhrase);
        }


        [Fact]
        public async Task GetAdminEvents_Member_Forbidden()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.GetAsync("api/event/admin/");
            await _testDataClient.DeleteUserAsync(testUser.UserId);

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Forbidden, httpResponseMessage.StatusCode);
        }

    }
}
