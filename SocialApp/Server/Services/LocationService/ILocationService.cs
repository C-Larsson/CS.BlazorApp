using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.LocationService
{
    public interface ILocationService
    {
        Task<ServiceResponse<List<Location>>> GetLocations();

        Task<ServiceResponse<List<Location>>> GetLocationSearchSuggestions(string searchText);

    }
}
