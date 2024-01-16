using Microsoft.EntityFrameworkCore;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.EventService
{

    public class EventService : IEventService
    {
        private readonly DataContext _context;
        private readonly ILogger<EventService> _logger;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public EventService(DataContext context, ILogger<EventService> logger, IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Event>> CreateEvent(Event event1)
        {
            try
            {
                event1.HostId = _authService.GetUserId();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user id");
                return new ServiceResponse<Event>
                {
                    Success = false,
                    Message = "Error getting user id"
                };
            }

            // Insert event into database
            await _context.Events.AddAsync(event1);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Event>()
            {
                Data = event1,
                Message = "Saved new event",
            };  
        }

        public async Task<ServiceResponse<Event>> UpdateEvent(Event event1)
        {
            var dbEvent = await _context.Events
                .Include(e => e.Images)
                .FirstOrDefaultAsync(e => e.Id == event1.Id);

            if (dbEvent == null)
            {
                return new ServiceResponse<Event>
                {
                    Success = false,
                    Message = "Event not found."
                };
            }

            dbEvent.Title = event1.Title;
            dbEvent.Description = event1.Description;
            dbEvent.StartDate = event1.StartDate;
            dbEvent.EndDate = event1.EndDate;
            dbEvent.ImageUrl = event1.ImageUrl;
            dbEvent.CategoryId = event1.CategoryId;
            dbEvent.LocationId = event1.LocationId;
            dbEvent.Price = event1.Price;
            dbEvent.CurrencyCode = event1.CurrencyCode;
            dbEvent.Visible = event1.Visible;

            var eventImages = dbEvent.Images;
            _context.Images.RemoveRange(eventImages);

            dbEvent.Images = event1.Images;

            await _context.SaveChangesAsync();
            return new ServiceResponse<Event> { Data = dbEvent };
        }


        public async Task<ServiceResponse<bool>> DeleteEvent(int eventId)
        {
            var dbEvent = await _context.Events.FindAsync(eventId);
            if (dbEvent == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Event not found."
                };
            }

            dbEvent.Deleted = true;
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

  
        public async Task<ServiceResponse<List<Event>>> GetEventsByCategory(string categoryUrl)
        {
            List<Event> events = await _context.Events
                    .Where(e => e.Category.Url.ToLower().Equals(categoryUrl.ToLower()) &&
                     e.Visible && !e.Deleted)
                    .Include(e => e.Images)
                    .ToListAsync();

            var response = new ServiceResponse<List<Event>>
            {
                Data = events
            };
            return response;
        }


        public async Task<ServiceResponse<List<string>>> GetEventSearchSuggestions(string searchText)
        {
            var events = await FindEventsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var e in events)
            {
                if (e.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(e.Title);
                }

                if (e.Description != null)
                {
                    var punctuation = e.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = e.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }
            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<List<Event>>> GetFeaturedEvents()
        {
            var events = await _context.Events
                .Where(e => e.Featured && e.Visible && !e.Deleted)
                .Include(e => e.Images)
                .ToListAsync();

            return new ServiceResponse<List<Event>>
            {
                Data = events
            };
        }

        public async Task<ServiceResponse<EventSearchResult>> SearchEvents(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindEventsBySearchText(searchText)).Count / pageResults);
            var events = await _context.Events
                                .Where(e => e.Title.ToLower().Contains(searchText.ToLower()) ||
                                    e.Description.ToLower().Contains(searchText.ToLower()) &&
                                    e.Visible && !e.Deleted)
                                .Include(e => e.Images)
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<EventSearchResult>
            {
                Data = new EventSearchResult
                {
                    Events = events,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        public async Task<ServiceResponse<List<Event>>> GetEvents()
        {
            var events = await _context.Events
                .Include(e => e.Images)
                .Where(e => e.Visible && !e.Deleted)
                .ToListAsync();

            return new ServiceResponse<List<Event>>
            {
                Data = events
            };
        }

        public async Task<ServiceResponse<List<Event>>> GetAdminEvents()
        {
            var events = await _context.Events.Where(e => !e.Deleted)
                .Include(e => e.Category)
                .Include(e => e.Location)
                .Include(e => e.Images)
                .ToListAsync();

            return new ServiceResponse<List<Event>>
            {
                Data = events
            };
        }

        public async Task<ServiceResponse<Event>> GetEvent(int eventId)
        {
            Event? event1 = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {

                event1 = await _context.Events
                     .Include(e => e.Images)
                     .Include(e => e.Category)
                     .Include(e => e.Location)
                    .FirstOrDefaultAsync(e => e.Id == eventId);
            } else
            {
                event1 = await _context.Events
                    .Include(e => e.Images)
                    .FirstOrDefaultAsync(e => e.Id == eventId && e.Visible && !e.Deleted);
            }

            if (event1 == null)
            {
                return new ServiceResponse<Event>
                {
                    Success = false,
                    Message = "Event not found."
                };
            }
            return new ServiceResponse<Event>()
            {
                Data = event1
            };
        }



        /// ////////////////////////////////////////////

        private async Task<List<Event>> FindEventsBySearchText(string searchText)
        {
            return await _context.Events
                                .Where(e => e.Title.ToLower().Contains(searchText.ToLower()) ||
                                    e.Description.ToLower().Contains(searchText.ToLower()) &&
                                    e.Visible && !e.Deleted)
                                .Include(e => e.Images)
                                .ToListAsync();
        }


 

        public async Task<ServiceResponse<bool>> UpdateAttendees(int eventId, int quantity)
        {
            var event1 = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            if (event1 == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Event not found."
                };
            }

            var spotsLeft = event1.MaxAttendees - event1.AttendeeCount;
            var spotsLeftAfterUpdate = spotsLeft - quantity;
            if (spotsLeftAfterUpdate <= 0 || spotsLeftAfterUpdate > event1.MaxAttendees)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = $"Event has {spotsLeft} spots left. Cannot add/remove {quantity} attendees"
                };
            }

            event1.AttendeeCount += quantity;
            _context.Events.Update(event1);
            return new ServiceResponse<bool>
            {
                Data = true
            };
        }

        public async Task<ServiceResponse<List<Event>>> GetMyEvents()
        {
            var userId = _authService.GetUserId();
            var events = await _context.Events.Where(e => e.HostId == userId && !e.Deleted)
              .Include(e => e.Category)
              .Include(e => e.Location)
              .Include(e => e.Images)
              .ToListAsync();

            if (events == null) {                 
                return new ServiceResponse<List<Event>>
                {
                    Success = false,
                    Message = "No events found."
                };
            }

            return new ServiceResponse<List<Event>>
            {
                Data = events
            };
        }
    }

}

