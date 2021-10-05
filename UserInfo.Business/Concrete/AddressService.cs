using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IDistributedCache _distributedCache;
        private readonly ICacheManipulation<AddressDto> _cacheManipulation;
        public AddressService(IAddressRepository addressRepository,IDistributedCache distributedCache,ICacheManipulation<AddressDto> cacheManipulation)
        {
            _addressRepository = addressRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = cacheManipulation;
        }
        public async Task<AddressDto> CreateAddress(AddressDto address)
        {
            var newAddress = await _addressRepository.CreateAddress(address);
            if (newAddress != null)
            {
                await _cacheManipulation.deleteItemCache("allAddress");
            }
            return newAddress;
        }

        public async Task DeleteAddress(int id)
        {
            await _addressRepository.DeleteAddress(id);
            await _cacheManipulation.deleteItemCache("address_" + id.ToString());
            await _cacheManipulation.deleteItemCache("allAddress");
        }

        public async Task<AddressDto> GetAddressById(int id)
        {
            var address = new AddressDto();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("address_" + id.ToString())))
            {
                var addressFromDb = await _addressRepository.GetAddressById(id);

                if (addressFromDb != null)
                {
                    await _cacheManipulation.SetItemInCache(addressFromDb, "address_" + id.ToString());
                    address = addressFromDb;
                }
                else
                {
                    address = null;
                }
            }
            else
            {
                address = await _cacheManipulation.GetItemFromCache("address_" + id.ToString());
            }

            return address;
        }

        public async Task<List<AddressDto>> GetAllAddress()
        {
            var allAddress = new List<AddressDto>();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("allAddress")))
            {
                var addressesFromDb = await _addressRepository.GetAllAddress();

                if (addressesFromDb != null)
                {
                    await _cacheManipulation.SetAllOfItemsInCache(addressesFromDb, "allAddress");
                    allAddress = addressesFromDb;
                }
                else
                {
                    allAddress = null;
                }
            }
            else
            {
                allAddress = await _cacheManipulation.GetAllOfItemsFromCache("allAddress");
            }

            return allAddress;
        }

        public async Task<AddressDto> UpdateAddress(AddressDto address)
        {
            var updateUser = await _addressRepository.UpdateAddress(address);
            if (updateUser != null)
            {
                await _cacheManipulation.deleteItemCache("address_" + updateUser.Id.ToString());
            }
            return updateUser;
        }
    }
}
