
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.EventService
{
    public interface IEventService
    {
        Task<ServiceResponse<Event>> CreateEvent(Event event1);
        Task<ServiceResponse<Event>> UpdateEvent(Event event1);
        Task<ServiceResponse<bool>> DeleteEvent(int eventId);
        Task<ServiceResponse<Event>> GetEvent(int eventId);

        Task<ServiceResponse<List<Event>>> GetAdminEvents();
        Task<ServiceResponse<List<Event>>> GetMyEvents();
        Task<ServiceResponse<List<Event>>> GetEvents();
        Task<ServiceResponse<List<Event>>> GetEventsByCategory(string categoryUrl);
        Task<ServiceResponse<List<Event>>> GetFeaturedEvents();

        Task<ServiceResponse<EventSearchResult>> SearchEvents(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetEventSearchSuggestions(string searchText);

        Task<ServiceResponse<bool>> UpdateAttendees(int eventId, int quantity);
    }


    
}
