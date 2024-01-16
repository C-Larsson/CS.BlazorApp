using Microsoft.AspNetCore.Mvc.Testing;

namespace SocialApp.IntegrationTest.TestSetups
{
    public class TestHttpClientFactory<TStartup> where TStartup : class
    {
        private readonly WebApplicationFactory<TStartup> _webApplicationFactory;

        public TestHttpClientFactory(WebApplicationFactory<TStartup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }



        public TestData.TestDataClient CreateTestDataClient()
        {
            var httpClientHandler = new HttpClientHandler();

            var httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri("https://localhost:7120/") };

            return new TestData.TestDataClient("https://localhost:7120/", httpClient);
        }
    }
}
