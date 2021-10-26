using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;
using UserInfo.Entities.Model;

namespace UserInfo.DataAccess.Concrete
{
    public class AddressRepository : IAddressRepository
    {
        private readonly UserDbContext _DbContext;
        private readonly IMapper _mapper;
        public AddressRepository(UserDbContext context,IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }
        public async Task<AddressDto> CreateAddress(AddressDto address)
        {
            var createAddress = _mapper.Map<Address>(address);
            _DbContext.Addresses.Add(createAddress);
            await _DbContext.SaveChangesAsync();
            return await GetAddressById(createAddress.Id);
        }

        public async Task DeleteAddress(int id)
        {
            var deleteAddress = await GetAddressById(id);
            if (deleteAddress != null)
            {
                var address = _mapper.Map<Address>(deleteAddress);
                _DbContext.Addresses.Remove(address);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<AddressDto> GetAddressById(int id)
        {
            var getAddress = await _DbContext.Addresses.Include(g => g.Geo)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (getAddress != null)
            {
                var address = _mapper.Map<AddressDto>(getAddress);
                return address;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<AddressDto>> GetAllAddress()
        {
            var getAddressList = await _DbContext.Addresses.Include(g => g.Geo)
                                            .ToListAsync();
            if (getAddressList != null)
            {
                var addressList = _mapper.Map<List<AddressDto>>(getAddressList);
                return addressList;

            }
            else
            {
                return null;
            }
        }

        public async Task<AddressDto> UpdateAddress(AddressDto address)
        {
            if (await GetAddressById(address.Id) != null)
            {
                var updateAddress = _mapper.Map<Address>(address);
                _DbContext.Addresses.Update(updateAddress);
                await _DbContext.SaveChangesAsync();
                address = await GetAddressById(updateAddress.Id);
            }
            else
            {
                address = null;
            }
            return address;
        }
    }
}
