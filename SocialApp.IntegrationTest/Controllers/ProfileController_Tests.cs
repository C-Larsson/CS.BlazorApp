using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SocialApp.IntegrationTest.Controllers
{
    public class ProfileController_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;


        public ProfileController_Tests(WebApplicationFactory<Program> factory)
        {
            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }


        [Fact]
        public async Task AddProfile_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var profile = new Profile()
            {
                Name = "Test Name",
                Bio = "Blah blah blaaahhh"
            };


            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Profile>("api/profile", profile);
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
            var serviceResponse = await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResponse<Profile>>();
            Assert.NotNull(serviceResponse);

            var userDb = await _testDataClient.GetUserbyEmailAsync(testUser.Email);
            await _testDataClient.DeleteUserByEmailAsync(testUser.Email);

            // Assert
            Assert.NotNull(userDb);
            Assert.NotNull(userDb.Profile);
            Assert.Equal(userDb.Email, testUser.Email);
            Assert.Equal(userDb.Profile.Name, profile.Name);
            Assert.Equal(userDb.Profile.Bio, profile.Bio);

        }

    }
}
