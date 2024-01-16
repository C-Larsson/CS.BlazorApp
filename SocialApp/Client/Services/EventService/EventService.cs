using Microsoft.AspNetCore.Components;
using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Json;

namespace SocialApp.Client.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly HttpClient _http;

        public EventService(HttpClient http)
        {
            _http = http;
        }

        public List<Event> Events { get; set; } = new List<Event>();
        public List<Event> AdminEvents { get; set; }
        public List<Event> MyEvents { get; set; }
        public string Message { get; set; } = "Loading events...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action EventsChanged;


        public async Task<Event> CreateEvent(Event request)
        {
            var result = await _http.PostAsJsonAsync<Event>("/api/event/single/", request);
            var newEvent = (await result.Content.ReadFromJsonAsync<ServiceResponse<Event>>()).Data;
            return newEvent;
        }

        public async Task<Event> UpdateEvent(Event request)
        {
            var result = await _http.PutAsJsonAsync($"api/event", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Event>>();
            return content.Data;
        }

        public async Task DeleteEvent(int eventId)
        {
            var result = await _http.DeleteAsync($"api/event/{eventId}");
        }

        public async Task<ServiceResponse<Event>> GetEvent(int eventId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Event>>($"api/event/{eventId}");
            return result;
        }

        public async Task GetEvents(string? categoryUrl = null)
        {
            // TODO: Fix to use featured API when categoryUrl is null
            categoryUrl = (categoryUrl == null) ? "featured" : categoryUrl;
            var  result = await _http.GetFromJsonAsync<ServiceResponse<List<Event>>>($"api/event/category/{categoryUrl}");
             
            if (result != null && result.Data != null)
               Events = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Events.Count == 0)
                Message = "No events found";

            EventsChanged.Invoke();
        }

        public async Task<List<string>> GetEventSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/event/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchEvents(string searchText, int page)
        {
            LastSearchText = searchText;
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<EventSearchResult>>($"api/event/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Events = result.Data.Events;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Events.Count == 0) Message = "No products found.";
            EventsChanged?.Invoke();
        }

        public async Task GetAdminEvents()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Event>>>($"api/event/admin");
            AdminEvents = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminEvents.Count == 0) Message = "No events found.";
        }

        public async Task<bool> GetMyEvents()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<Event>>>($"api/event/my");
                
                MyEvents = result.Data;
                Message = result.Message;
                return result.Success;
            }
            catch (Exception ex)
            {
                // if unauthorized, redirect to login
                if (ex.Message.Contains("401")) { 
                    Message = "Unauthorized";
                }
                return false;
            }
        }
    }
}
