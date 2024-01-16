using Microsoft.AspNetCore.Mvc.Testing;
using SocialApp.IntegrationTest.TestSetups;
using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SocialApp.IntegrationTest.Controllers
{
    public class CategoryController_OK_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private readonly TestData.TestDataClient _testDataClient;

        public CategoryController_OK_Tests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
            
            var testHttpClientFactory = new TestHttpClientFactory<Program>(factory);
            _testDataClient = testHttpClientFactory.CreateTestDataClient();
        }


        [Fact]
        public async Task GetCategories_OK()
        {
            // Prepare and Act
            var httpResponseMessage = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("/api/category/");

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.True(httpResponseMessage.Success);
            var categories = httpResponseMessage.Data;
            Assert.NotNull(categories);
            Assert.Equal(1, categories[0].Id);
            Assert.Equal("Home Gatherings and Parties", categories[0].Name);
        }

        [Fact]
        public async Task GetAdminCategories_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("admin");
            Assert.NotNull(testUser);


            // Act
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", testUser.Token);
            var httpResponseMessage = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("/api/category/admin");
            await _testDataClient.DeleteUserByEmailAsync(testUser.Email);

            // Assert
            Assert.NotNull(httpResponseMessage);
            Assert.True(httpResponseMessage.Success);
            var categories = httpResponseMessage.Data;
            Assert.NotNull(categories);
            Assert.Equal(1, categories[0].Id);
            Assert.Equal("Home Gatherings and Parties", categories[0].Name);
        }


        [Fact]
        public async Task AddCategory_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("admin");
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
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var category = await _testDataClient.GetCategoryByNameAsync(newCategory.Name);
            Assert.NotNull(category);

            await _testDataClient.DeleteCategoryAsync(category.Id);
            await _testDataClient.DeleteUserAsync(testUser.UserId);

            // Assert
            Assert.Equal(newCategory.Name, category.Name);
        }


        [Fact]
        public async Task UpdateCategory_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("admin");
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
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var updatedCategoryFromDb = await _testDataClient.GetCategoryByNameAsync(updatedCategory.Name);
            await _testDataClient.DeleteCategoryAsync(updatedCategoryFromDb.Id);
            await _testDataClient.DeleteUserAsync(testUser.UserId);

            Assert.NotNull(updatedCategoryFromDb);
            Assert.True(updatedCategoryFromDb.Id == updatedCategory.Id);
            Assert.Equal(updatedCategory.Name, updatedCategoryFromDb.Name);
        }


        [Fact]
        public async Task DeleteCategory_OK()
        {
            // Prepare
            var testUser = await _testDataClient.GenerateTestUserAsync("admin");
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
            Assert.NotNull(httpResponseMessage);
            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);

            var deletedCategory = await _testDataClient.GetCategoryByNameAsync(newCategory.Name);

            await _testDataClient.DeleteUserAsync(testUser.UserId);
            await _testDataClient.DeleteCategoryAsync(category.Id);

            // Assert
            Assert.NotNull(deletedCategory);
            Assert.True(category.Id == deletedCategory.Id);
            Assert.Equal(category.Name, deletedCategory.Name);
            Assert.True(deletedCategory.Deleted);
        }
    }
}
