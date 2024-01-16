using Microsoft.EntityFrameworkCore;
using SocialApp.Server.Data;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Location>>> GetLocations()
        {
            var response = new ServiceResponse<List<Location>>();
            try
            {
                response.Data = await _context.Locations.ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Location>>> GetLocationSearchSuggestions(string searchText)
        {
            var locations = await _context.Locations
                                .Where(l => l.City.ToLower().Contains(searchText.ToLower())).ToListAsync();

            /*
            List<Location> result = new List<Location>();
            foreach (var location in locations)
            {
                if (location.City.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(location);
                }
            } */

            return new ServiceResponse<List<Location>> { Data = locations };
        }


    }



}
