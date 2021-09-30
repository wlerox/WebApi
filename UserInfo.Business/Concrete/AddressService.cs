using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;
        //private readonly IDistributedCache _distributedCache;
        //private CacheManipulation _cacheManipulation;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            //_distributedCache = distributedCache;
            //_cacheManipulation = new CacheManipulation(_distributedCache);
        }
        public async Task<AddressDto> CreateAddress(AddressDto address)
        {
            var newAddress = await _addressRepository.CreateAddress(address);
            return newAddress;
        }

        public async Task DeleteAddress(int id)
        {
            await _addressRepository.DeleteAddress(id);
        }

        public async Task<AddressDto> GetAddressById(int id)
        {
            return await _addressRepository.GetAddressById(id);
        }

        public async Task<List<AddressDto>> GetAllAddress()
        {
            return await _addressRepository.GetAllAddress();
        }

        public async Task<AddressDto> UpdateAddress(AddressDto address)
        {
            var updateUser = await _addressRepository.UpdateAddress(address);

            return updateUser;
        }
    }
}
