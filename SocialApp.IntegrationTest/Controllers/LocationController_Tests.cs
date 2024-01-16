using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Json;

namespace SocialApp.IntegrationTest.Controllers
{
    public class LocationController_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;

        public LocationController_Tests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task GetEventSearchSuggestions_OK()
        {
            // Prepare
            var searchText = "Ban";

            // Act
            var response = await _httpClient.GetAsync($"api/location/searchsuggestions/{searchText}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Location>>>();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Success);
            Assert.Equal(1, result.Data.Count);
            Assert.Equal("Bangkok", result.Data[0].City);

        }   





    }
}
