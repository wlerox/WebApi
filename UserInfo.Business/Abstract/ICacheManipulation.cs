using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface ICacheManipulation
    {
        Task<List<UserDto>> GetAllUsersFromCache();
        Task<UserDto> GetUserFromCache(String key);
        Task SetUsersInCache(List<UserDto> allUsers);
        Task SetUserInCache(UserDto user, String key);
        Task deleteItemCache(String key);
    }
}
