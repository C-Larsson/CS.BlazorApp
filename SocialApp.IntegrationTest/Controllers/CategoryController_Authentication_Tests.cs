using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SocialApp.IntegrationTest.Controllers
{
    public class CategoryController_Authentication_Tests : IClassFixture<WebApplicationFactory<Program>>
    {


        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;

        public CategoryController_Authentication_Tests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();

            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
        }


        [Fact]
        public async Task AddCategory_NoToken_Unauthorized()
        {
            // Prepare
            var newCategory = new Category()
            {
                Name = "Test Category",
                Url = "test"
            };

            // Act
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Category>("/api/category/admin", newCategory);
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async Task AddCategory_Member_Forbidden()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var newCategory = new Category()
            {
                Name = "Test Category",
                Url = "test"
            };

            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.PostAsJsonAsync<Category>("/api/category/admin", newCategory);
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Forbidden, httpResponseMessage.StatusCode);

            await _testDataClient.DeleteUserAsync(testUser.UserId);
        }


        [Fact]
        public async Task UpdateCategory_NoToken_Unauthorized()
        {
            // Prepare
            var newCategory = new TestData.Category()
            {
                Name = "Test Category",
                Description = "Test Description",
                Url = "test"
            };


            var category = await _testDataClient.AddCategoryAsync(newCategory);

            var updatedCategory = new Category()
            {
                Id = category.Id,
                Name = "Updated Category",
                Description = "Updated Description",
                Url = "updated"
            };

            // Act
            var httpResponseMessage = await _httpClient.PutAsJsonAsync<Category>("/api/category/admin", updatedCategory);
            await _testDataClient.DeleteCategoryAsync(category.Id);

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async Task UpdateCategory_Member_Forbidden()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var newCategory = new TestData.Category()
            {
                Name = "Test Category",
                Description = "Test Description",
                Url = "test"
            };

            // Act
            var category = await _testDataClient.AddCategoryAsync(newCategory);

            var updatedCategory = new Category()
            {
                Id = category.Id,
                Name = "Updated Category",
                Description = "Updated Description",
                Url = "updated"
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.PutAsJsonAsync<Category>("/api/category/admin", updatedCategory);
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Forbidden, httpResponseMessage.StatusCode);

      
        }

        [Fact]
        public async Task DeleteCategory_Member_Forbidden()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);

            var newCategory = new TestData.Category()
            {
                Name = "Test Category",
                Description = "Test Description",
                Url = "test"
            };

            // Act
            var category = await _testDataClient.AddCategoryAsync(newCategory);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.DeleteAsync($"/api/category/admin/{category.Id}");
            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteCategoryAsync(category.Id);

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Forbidden, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async Task DeleteCategory_NoLogin_Unauthorized()
        {
            // Prepare
            var newCategory = new TestData.Category()
            {
                Name = "Test Category",
                Description = "Test Description",
                Url = "test"
            };

            // Act
            var category = await _testDataClient.AddCategoryAsync(newCategory);
            var httpResponseMessage = await _httpClient.DeleteAsync($"/api/category/admin/{category.Id}");
            await _testDataClient.DeleteCategoryAsync(category.Id);

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);

        }

        [Fact]
        public async Task GetAdminCategories_Member_Forbidden()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("member");
            Assert.NotNull(testUser);


            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.GetAsync("/api/category/admin");
            await _testDataClient.DeleteUserByEmailAsync("member@gmail.com");

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Forbidden, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async Task GetAdminCategories_NoLogin_Unauthorized()
        {
            // Act
            var httpResponseMessage = await _httpClient.GetAsync("/api/category/admin");

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, httpResponseMessage.StatusCode);
        }


    }
}
