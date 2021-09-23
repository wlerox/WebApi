using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;

namespace UserInfo.Business.Concrete
{
    public class GeolocationService : IGeolocationService
    {
        private IGeolocationRepository _geolocationRepository;
        private readonly IDistributedCache _distributedCache;
        private CacheManipulation _cacheManipulation;
        public GeolocationService(IGeolocationRepository geolocationRepository, IDistributedCache distributedCache)
        {
            _geolocationRepository = geolocationRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = new CacheManipulation(_distributedCache);
            //_userRepository = new UserRepository();
        }
        public async Task<Geolocation> CreateGeolocation(Geolocation geolocation)
        {
            var newGeolocation = await _geolocationRepository.CreateGeolocation(geolocation);
            /*if (newAddress != null)
            {
                //newUser = await _userRepository.GetUserById(user.Id);
                //await _cacheManipulation.SetUserInCache(newUser, newUser.Id.ToString());
                var addressFromDb = await _addressRepository.GetAllAddress();
                if (addressFromDb != null)
                {
                    await _cacheManipulation.SetUsersInCache(addressFromDb);
                }
            }*/

            return newGeolocation;
        }

        public async Task DeleteGeolocation(int id)
        {
            await _geolocationRepository.DeleteGeolocation(id);
            //await _cacheManipulation.deleteItemCache(id.ToString());

            /*var usersFromDb = await _addressRepository.GetAllAddress();
            if (usersFromDb != null)
            {
                await _cacheManipulation.SetUsersInCache(usersFromDb);
            }*/
        }

        public async Task<List<Geolocation>> GetAllGeolocation()
        {
            /*var allUsers = new List<User>();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("allUsers")))
            {
                var usersFromDb = await _userRepository.GetAllUsers();

                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetUsersInCache(usersFromDb);
                    //allUsers = await _cacheManipulation.GetAllUsersFromCache(_distributedCache, "allUsers");
                    allUsers = usersFromDb;
                }
                else
                {
                    allUsers = null;
                }

            }
            else
            {
                allUsers = await _cacheManipulation.GetAllUsersFromCache();
            }*/

            return await _geolocationRepository.GetAllGeolocation();
        }

        public async Task<Geolocation> GetGeolocationById(int id)
        {
            /*var user = new User();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("user_" + id.ToString())))
            {
                var userFromDb = await _userRepository.GetUserById(id);

                if (userFromDb != null)
                {
                    await _cacheManipulation.SetUserInCache(userFromDb, id.ToString());
                    //user = await _cacheManipulation.GetUserFromCache(_distributedCache, id.ToString());
                    user = userFromDb;
                }
                else
                {
                    user = null;
                }
            }
            else
            {
                user = await _cacheManipulation.GetUserFromCache(id.ToString());
            }*/

            return await _geolocationRepository.GetGeolocationById(id);
        }

        public async Task<Geolocation> UpdateGeolocation(Geolocation geolocation)
        {
            var updateGeolocation = await _geolocationRepository.UpdateGeolocation(geolocation);
            /*if (updateUser != null)
            {
                await _cacheManipulation.deleteItemCache(user.Id.ToString());
                //await _cacheManipulation.SetUserInCache(updateUser, user.Id.ToString());
                var usersFromDb = await _userRepository.GetAllUsers();

                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetUsersInCache(usersFromDb);
                }
            }*/


            return updateGeolocation;
        }
    }
}
