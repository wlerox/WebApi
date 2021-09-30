using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class CacheManipulation: ICacheManipulation
    {
        readonly IDistributedCache _distributedCache;
        public CacheManipulation(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        //get all users from redis cache
        public async Task<List<UserDto>> GetAllUsersFromCache()
        {
            var usersFromCache = await _distributedCache.GetStringAsync("allUsers");
            var allUsers = JsonConvert.DeserializeObject<List<UserDto>>(usersFromCache);
            return allUsers;
        }
        //get only one user from redis cache
        public async Task<UserDto> GetUserFromCache(String key)
        {
            var userFromCache = await _distributedCache.GetStringAsync("user_" + key);
            var user = JsonConvert.DeserializeObject<UserDto>(userFromCache);

            return user;

        }
        //put all users in redis cache
        public async Task SetUsersInCache(List<UserDto> allUsers)
        {
            var allUsersInString = JsonConvert.SerializeObject(allUsers);
            await _distributedCache.SetStringAsync("allUsers", allUsersInString);
        }
        //put one user in redis cache
        public async Task SetUserInCache(UserDto user, String key)
        {
            var UserInString = JsonConvert.SerializeObject(user);
            await _distributedCache.SetStringAsync("user_" + key, UserInString);
        }
        //delete user or all users from redis cache
        public async Task deleteItemCache(String key)
        {
            await _distributedCache.RemoveAsync("user_" + key);
        }
    }
}
