using SocialApp.Shared.Models.Tables;

namespace SocialApp.Client.Services.LocationService
{
    public interface ILocationService
    {
        List<Location> Locations { get; set; }

        Task GetLocations();

        Task GetSearchSuggestions(string searchText);


    }
}
