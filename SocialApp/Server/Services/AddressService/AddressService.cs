using Microsoft.EntityFrameworkCore;
using SocialApp.Shared.Models.Tables;

namespace SocialApp.Server.Services.AddressService
{
    public class AddressService : IAddressService
    {

        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public AddressService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<Address>> AddUserAddress(Address address)
        {
            var userId = _authService.GetUserId();
      

            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return new ServiceResponse<Address>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            user.Address = address;
            await _context.SaveChangesAsync();
            return new ServiceResponse<Address>
            {
                Data = address
            };
        }

        public Task DeleteAddress(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Address>> GetUserAddress()
        {
             var userId = _authService.GetUserId();

            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null || user.Address == null)
            {
                return new ServiceResponse<Address>
                {
                    Success = false,
                    Message = "User/Address not found."
                };
            }
            return new ServiceResponse<Address>
            {
                Data = user.Address
            };
        }

        public async Task<ServiceResponse<Address>> UpdateUserAddress(Address address)
        {
            var userId = _authService.GetUserId(); 

            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null || user.Address == null)
            {
                return new ServiceResponse<Address>
                {
                    Success = false,
                    Message = "User/Address not found."
                };
            }

            user.Address.Name = address.Name;
            user.Address.Street = address.Street;
            user.Address.City = address.City;
            user.Address.State = address.State;
            user.Address.PostalCode = address.PostalCode;
            user.Address.Country = address.Country;
            await _context.SaveChangesAsync();
            return new ServiceResponse<Address>
            {
                Data = address
            };
        }
    }
}
