using SocialApp.Shared.Models;
using SocialApp.Shared.Models.Tables;
using System.Net.Http.Json;

namespace SocialApp.Client.Services.AddressService
{
    public class AddressService : IAddressService
    {

        public readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Address Address { get; set; } = null;

        public event Action OnChange;

        public async Task AddUserAddress(Address address)
        {
            var result = await _httpClient.PostAsJsonAsync("api/address", address);
            Address = (await result.Content.ReadFromJsonAsync<ServiceResponse<Address>>()).Data;
            OnChange.Invoke();
        }

        public Address CreateNewAddress()
        {
            var newAddress = new Address() { IsNew = true, Editing = true };
            Address = newAddress;
            OnChange.Invoke();
            return newAddress;
        }

        public async Task GetUserAddress()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Address>>("api/address");
            if (result != null && result.Data != null)
                Address = result.Data;
        }

        public async Task UpdateUserAddress(Address address)
        {
            var response = await _httpClient.PutAsJsonAsync("api/address", address);
            Address = (await response.Content.ReadFromJsonAsync<ServiceResponse<Address>>()).Data;
            OnChange.Invoke();
        }

    }
}
