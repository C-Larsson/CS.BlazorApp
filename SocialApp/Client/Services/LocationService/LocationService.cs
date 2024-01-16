using SocialApp.Client.Pages.Admin;
using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Json;

namespace SocialApp.Client.Services.LocationService
{
    public class LocationService : ILocationService
    {
        
        private readonly HttpClient _http;

        public LocationService(HttpClient http)
        {
            _http = http;
        }
        
        public List<Location> Locations { get; set; } = new List<Location>();

        public async Task GetLocations()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Location>>>("api/location");
            if (response != null && response.Data != null)
                Locations = response.Data;
        }

        public async Task GetSearchSuggestions(string searchText)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Location>>>($"api/location/searchsuggestions/{searchText}");
            if (response != null && response.Data != null)
                Locations = response.Data;
        }

    }
}
