using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;

namespace UserInfo.DataAccess.Concrete
{
    public class AddressRepository : IAddressRepository
    {
        private readonly UserDbContext _DbContext;
        public AddressRepository(UserDbContext context)
        {
            _DbContext = context;
        }
        public async Task<Address> CreateAddress(Address address)
        {
            _DbContext.Addresses.Add(address);
            await _DbContext.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddress(int id)
        {
            var deleteAddress = await GetAddressById(id);
            if (deleteAddress != null)
            {
                _DbContext.Addresses.Remove(deleteAddress);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<Address> GetAddressById(int id)
        {
            var address = await _DbContext.Addresses.Include(g => g.Geo)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (address != null)
            {
                return address;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Address>> GetAllAddress()
        {
            var address = await _DbContext.Addresses.Include(g => g.Geo)
                                            .ToListAsync();
            if (address != null)
            {
                return address;
            }
            else
            {
                return null;
            }
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            if (await GetAddressById(address.Id) != null)
            {
                _DbContext.Addresses.Update(address);
                await _DbContext.SaveChangesAsync();
            }
            else
            {
                address = null;
            }
            return address;
        }
    }
}
