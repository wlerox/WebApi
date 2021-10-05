using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface ICacheManipulation<T> where T:class
    {
        Task<List<T>> GetAllOfItemsFromCache(String key);
        Task<T> GetItemFromCache(String key);
        Task SetAllOfItemsInCache(List<T> allitems, String key);
        Task SetItemInCache(T item, String key);
        Task deleteItemCache(String key);
    }
}
