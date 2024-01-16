using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.IntegrationTest.Controllers
{
    public class EventController_Tests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;

        public EventController_Tests(WebApplicationFactory<Program> factory)
        {
            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }


        [Fact]
        public async Task GetFeaturedEvents_OK()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Event>>>($"api/event/featured");
            Assert.True(response.Success);
            
            List<Event> feauredEvents = response.Data;

            // Assert
            Assert.Equal(4, feauredEvents.Count);
        }

        [Fact]
        public async Task GetAdminEvents_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("admin");
            Assert.NotNull(testUser);

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var serviceResponse = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Event>>>($"api/event/admin");
            await _testDataClient.DeleteUserAsync(testUser.UserId);

            // Assert
            Assert.NotNull(serviceResponse);
            Assert.NotNull(serviceResponse.Data);
            Assert.True(serviceResponse.Success);
            Assert.True(serviceResponse.Data.Count > 5);
        }


        [Fact]
        public async Task CreateEvent_OK()
        {
            // Arrange
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var singleEvent = new Event()
            {
              Title = "Test Event",
              CategoryId = 1,
              LocationId = 1,
              StartDate = DateTime.Now.AddDays(2),
              EndDate = DateTime.Now.AddDays(2).AddHours(2),
            };

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Event>("/api/event/single/", singleEvent);
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
            var newEvent = (await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResponse<Event>>()).Data;
            Assert.NotNull(newEvent);

            var eventFromDb = await _testDataClient.GetEventAsync(newEvent.Id);

            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteEventAsync(newEvent.Id);

            // Assert
            Assert.Equal(newEvent.Id, eventFromDb.Id);
            Assert.Equal(singleEvent.Title, eventFromDb.Title);
            Assert.Equal(singleEvent.CategoryId, eventFromDb.CategoryId);
            Assert.Equal(testUser.UserId, eventFromDb.HostId);
        }


        [Fact]
        public async Task UpdateEvent_OK()
        {
            // Arrange
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var testEvent = new Event()
            {
                Title = "Test Event",
                CategoryId = 1,
                LocationId = 1,
                HostId = 1,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Event>("/api/event/single/", testEvent);
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
            var createdEvent = (await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResponse<Event>>()).Data;

            // Act
            testEvent.Id = createdEvent.Id;
            testEvent.Title = "Updated Event";
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            httpResponseMessage = await _httpClient.PutAsJsonAsync<Event>("/api/event/", testEvent);
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
            var updatedEvent = (await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResponse<Event>>()).Data;
 
            var eventFromDb = await _testDataClient.GetEventAsync(updatedEvent.Id);

            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteEventAsync(updatedEvent.Id);

            // Assert
            Assert.Equal(testEvent.Id, eventFromDb.Id);
            Assert.Equal(testEvent.Title, eventFromDb.Title);
        }

        [Fact]
        public async Task DeleteEvent_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var testEvent = new Event()
            {
                Title = "Test Event",
                CategoryId = 1,
                LocationId = 1,
                HostId = 1,
                StartDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Event>("/api/event/single/", testEvent);
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
            var createdEvent = (await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResponse<Event>>()).Data;

            // Act
            httpResponseMessage = await _httpClient.DeleteAsync($"/api/event/{createdEvent.Id}");
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var eventFromDb = await _testDataClient.GetEventAsync(createdEvent.Id);

            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteEventAsync(createdEvent.Id);

            // Assert
            Assert.True(eventFromDb.Deleted);

        }

    }
}
