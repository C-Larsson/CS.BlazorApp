using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SocialApp.IntegrationTest.Controllers
{
    public class AddressController_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;


        public AddressController_Tests(WebApplicationFactory<Program> factory)
        {
            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }


        [Fact]
        public async Task AddUserAddress_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");

            var address = new Address()
            {
                Street = "Test Street",
                City = "Test City",
                Country = "Test Country",
                PostalCode = "177 43"
            };


            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Address>("/api/address/", address);
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var userDb = await _testDataClient.GetUserbyEmailAsync(testUser.Email);
            await _testDataClient.DeleteUserByEmailAsync(testUser.Email);

            // Assert
            Assert.NotNull(userDb);
            Assert.NotNull(userDb.Address);
            Assert.Equal(userDb.Email, testUser.Email);
            Assert.Equal(address.Street, userDb.Address.Street);
            Assert.Equal(address.City, userDb.Address.City);
            Assert.Equal(address.Country, userDb.Address.Country);
        }

    }
}
