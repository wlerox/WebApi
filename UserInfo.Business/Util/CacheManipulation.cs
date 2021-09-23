using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities;

namespace UserInfo.Business.Concrete
{
    public class CacheManipulation
    {
        readonly IDistributedCache _distributedCache;
        public CacheManipulation(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task<List<User>> GetAllUsersFromCache()
        {
            var usersFromCache = await _distributedCache.GetStringAsync("allUsers");
            var allUsers = JsonConvert.DeserializeObject<List<User>>(usersFromCache);
            return allUsers;
        }
        public async Task<User> GetUserFromCache(String key)
        {
            var userFromCache = await _distributedCache.GetStringAsync("user_"+key);
            var user = JsonConvert.DeserializeObject<User>(userFromCache);
            
            return user;
            
        }
        public async Task SetUsersInCache(List<User>allUsers)
        {
            var allUsersInString = JsonConvert.SerializeObject(allUsers);
            await _distributedCache.SetStringAsync("allUsers", allUsersInString);
        }
        public async Task SetUserInCache(User user, String key)
        {
            var UserInString = JsonConvert.SerializeObject(user);
            await _distributedCache.SetStringAsync("user_"+key, UserInString);
        }
        public async Task deleteItemCache(String key)
        {
            await _distributedCache.RemoveAsync("user_"+key);
        }
    }
}
