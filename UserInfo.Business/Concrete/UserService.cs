using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDistributedCache _distributedCache;
        private readonly ICacheManipulation<UserDto> _cacheManipulation;
        public UserService(IUserRepository userRepository, IDistributedCache distributedCache, ICacheManipulation<UserDto> cacheManipulation)
        {
            _userRepository = userRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = cacheManipulation;
            //_userRepository = new UserRepository();
        }
        public async Task<UserDto> CreateUser(UserDto user)
        {
            var newUser = await _userRepository.CreateUser(user);
            if (newUser != null)
            {
                var usersFromDb = await _userRepository.GetAllUsers();
                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetAllOfItemsInCache(usersFromDb, "allUser");
                }
            }

            return newUser;
        }

        public async Task DeleteUserById(int id)
        {
            await _userRepository.DeleteUser(id);
            await _cacheManipulation.deleteItemCache("user_" + id.ToString());

            var usersFromDb = await _userRepository.GetAllUsers();
            if (usersFromDb != null)
            {
                await _cacheManipulation.SetAllOfItemsInCache(usersFromDb, "allUser");
            }
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var allUsers = new List<UserDto>();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("allUser")))
            {
                var usersFromDb = await _userRepository.GetAllUsers();

                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetAllOfItemsInCache(usersFromDb, "allUser");
                    allUsers = usersFromDb;
                }
                else
                {
                    allUsers = null;
                }

            }
            else
            {
                allUsers = await _cacheManipulation.GetAllOfItemsFromCache("allUser");
            }

            return allUsers;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = new UserDto();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("user_" + id.ToString())))
            {
                var userFromDb = await _userRepository.GetUserById(id);

                if (userFromDb != null)
                {
                    await _cacheManipulation.SetItemInCache(userFromDb, "user_" + id.ToString());
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
                user = await _cacheManipulation.GetItemFromCache("user_" + id.ToString());
            }

            return user;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var updateUser = await _userRepository.UpdateUser(user);
            if (updateUser != null)
            {
                await _cacheManipulation.deleteItemCache("user_" + updateUser.Id.ToString());
                var usersFromDb = await _userRepository.GetAllUsers();

                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetAllOfItemsInCache(usersFromDb, "allUser");
                }
            }
            return updateUser;
        }
    }
}
