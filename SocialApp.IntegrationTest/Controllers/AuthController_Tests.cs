using Azure;
using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TestData;

namespace SocialApp.IntegrationTest.Controllers
{
    public class AuthController_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;
        

        public AuthController_Tests(WebApplicationFactory<Program> factory)
        {
            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task RegisterUser_OK()
        {
            // Prepare
            var email = $"test{Guid.NewGuid().ToString().Substring(0, 5)}@gmail.com";
            var password = "abcde12345";

            // Act
            var response = await RegisterUser(email, password);
            var user = await _testDataClient.GetUserbyEmailAsync(email);
            await _testDataClient.DeleteUserByEmailAsync(email);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(email, user.Email);
        }

        [Fact]
        public async Task RegisterUser_UserEmailExists()
        {
            // Prepare
            var email = $"test{Guid.NewGuid().ToString().Substring(0, 5)}@gmail.com";
            var password = "abcde12345";

            // Act
            var response = await RegisterUser(email, password);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            response = await RegisterUser(email, password);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
            await _testDataClient.DeleteUserByEmailAsync(email);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(result.Success);
            Assert.Equal("User already exists.", result.Message);
        }

        [Fact]
        public async Task LoginUser__OK()
        {
            // Prepare
            var email = $"test{Guid.NewGuid().ToString().Substring(0, 5)}@gmail.com";
            var password = "abcde12345";

            var response = await RegisterUser(email, password);
            
            // Act
            response = await LoginUser(email, password, false);
            var result = (await response.Content.ReadFromJsonAsync<ServiceResponse<string>>());
            _testDataClient.DeleteUserByEmailAsync(email);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            //Assert.Equal(512, result.Data.Length);
        }

        [Fact]
        public async Task LoginUserStaySignedIn__OK()
        {
            // Prepare
            var email = $"test{Guid.NewGuid().ToString().Substring(0, 5)}@gmail.com";
            var password = "abcde12345";

            await RegisterUser(email, password);
            
            // Act
            var response = await LoginUser(email, password, true);
            var result = (await response.Content.ReadFromJsonAsync<ServiceResponse<string>>());
            response.Headers.TryGetValues("Set-Cookie", out var refreshTokenCookie);
            var refreshToken = refreshTokenCookie.FirstOrDefault().Split("=")[1].Split(";")[0]; 
            

            var user = await _testDataClient.GetUserbyEmailAsync(email);
            _testDataClient.DeleteUserByEmailAsync(email);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);            
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(refreshToken, user.RefreshToken);
        }

        [Fact]
        public async Task RefreshToken_OK()
        {
            // Prepare
            var email = $"test{Guid.NewGuid().ToString().Substring(0, 5)}@gmail.com";
            var password = "abcde12345";
            await RegisterUser(email, password);
            var response = await LoginUser(email, password, true);
            response.Headers.TryGetValues("Set-Cookie", out var refreshTokenCookie1);
            var request = new RefreshTokenRequest()
            {
                RefreshToken = refreshTokenCookie1.FirstOrDefault().Split("=")[1].Split(";")[0]
            };

            // Act
            response = await _httpClient.PostAsJsonAsync<RefreshTokenRequest>("api/auth/refresh-token/", request);
            response.Headers.TryGetValues("Set-Cookie", out var refreshTokenCookie2);
            var refreshToken2 = refreshTokenCookie2.FirstOrDefault().Split("=")[1].Split(";")[0];
            var result = (await response.Content.ReadFromJsonAsync<ServiceResponse<string>>());
            var user = await _testDataClient.GetUserbyEmailAsync(email);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal(refreshToken2, user.RefreshToken);
        }


        [Fact]
        public async Task ChangePassword_OK()
        {
            // Prepare
            var email = $"test{Guid.NewGuid().ToString().Substring(0, 5)}@gmail.com";
            var oldPassword = "abcde12345";
            var newPassword = "4321dcba##";

            var response = await RegisterUser(email, oldPassword);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            response = await LoginUser(email, oldPassword, false);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var token1 = (await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()).Data;

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token1);
            var changePasswordResponse = await _httpClient.PostAsJsonAsync<string>("/api/auth/change-password/", newPassword);
            Assert.Equal(System.Net.HttpStatusCode.OK, changePasswordResponse.StatusCode);
            var result = await changePasswordResponse.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

            // Asssert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.True(result.Data);

            response = await LoginUser(email, newPassword, false);
            await _testDataClient.DeleteUserByEmailAsync(email);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task ChangePassword_Unauthorized()
        {
            // Prepare
            var newPassword = "thenewpassword";

            // Act
            var changePasswordResponse = await _httpClient.PostAsJsonAsync<string>("/api/auth/change-password/", newPassword);
            
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, changePasswordResponse.StatusCode);
 
        }



        private async Task<HttpResponseMessage> RegisterUser(string email, string password)
        {
 
            var newUser = new UserRegister()
            {
                Email = email,
                Password = password,
                RepeatPassword = password,
            };
            return await _httpClient.PostAsJsonAsync<UserRegister>("/api/auth/register/", newUser);
        }

        private async Task<HttpResponseMessage> LoginUser(string email, string password, bool staySignedIn)
        {
            var request = new UserLogin()
            {
                Email = email,
                Password = password,
                StaySignedIn = staySignedIn
            };
            return await _httpClient.PostAsJsonAsync<UserLogin>("api/auth/login/", request);
        }

    }
}
