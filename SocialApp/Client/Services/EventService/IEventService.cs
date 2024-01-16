using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Client.Services.EventService
{
    public interface IEventService
    {

        event Action EventsChanged;
        List<Event> Events { get; set; }
        List<Event> AdminEvents { get; set; }
        public List<Event> MyEvents { get; set; }

        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task<Event> CreateEvent(Event event1);
        Task<Event> UpdateEvent(Event event1);
        Task DeleteEvent(int eventId);

        Task<bool> GetMyEvents();

        // Returns featured events, if categoryUrl is null
        Task GetEvents(string? categoryUrl = null);
        Task<ServiceResponse<Event>> GetEvent(int eventId);

        Task SearchEvents(string searchText, int page);
        Task<List<string>> GetEventSearchSuggestions(string searchText);

        Task GetAdminEvents();
  


    }
}
