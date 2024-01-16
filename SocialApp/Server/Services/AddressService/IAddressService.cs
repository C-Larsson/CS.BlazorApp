using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.AddressService
{
    public interface IAddressService
    { 

        Task<ServiceResponse<Address>> AddUserAddress(Address address);     
        Task<ServiceResponse<Address>> UpdateUserAddress(Address address);
        Task<ServiceResponse<Address>> GetUserAddress();

        Task DeleteAddress(int id);

    }
}
