using SocialApp.Shared.Models.Tables;

namespace SocialApp.Client.Services.AddressService
{
    public interface IAddressService
    {

        event Action OnChange;
        Address Address { get; set; }

        Task GetUserAddress();

        Address CreateNewAddress();
        Task AddUserAddress(Address address);
        Task UpdateUserAddress(Address address);
        
    }
}
