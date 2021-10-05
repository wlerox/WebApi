using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;

namespace UserInfo.Business.Concrete
{
    public class CacheManipulation<T>: ICacheManipulation<T> where T:class
    {
        readonly IDistributedCache _distributedCache;
        public CacheManipulation(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        //get all users from redis cache
        public async Task<List<T>> GetAllOfItemsFromCache(String key)
        {
            var itemsFromCache = await _distributedCache.GetStringAsync(key);
            var allItems = JsonConvert.DeserializeObject<List<T>>(itemsFromCache);
            return allItems;
        }
        //get only one user from redis cache
        public async Task<T> GetItemFromCache(String key)
        {
            var itemFromCache = await _distributedCache.GetStringAsync(key);
            var item = JsonConvert.DeserializeObject<T>(itemFromCache);

            return item;

        }
        //put all users in redis cache
        public async Task SetAllOfItemsInCache(List<T> allItems, String key)
        {
            var allItemsInString = JsonConvert.SerializeObject(allItems);
            await _distributedCache.SetStringAsync(key, allItemsInString);
        }
        //put one user in redis cache
        public async Task SetItemInCache(T item, String key)
        {
            var itemInString = JsonConvert.SerializeObject(item);
            await _distributedCache.SetStringAsync(key, itemInString);
        }
        //delete user or all users from redis cache
        public async Task deleteItemCache(String key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}
