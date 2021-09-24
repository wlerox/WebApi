using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;

namespace UserInfo.Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IDistributedCache _distributedCache;
        private CacheManipulation _cacheManipulation;
        public UserService(IUserRepository userRepository,IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = new CacheManipulation(_distributedCache);
            //_userRepository = new UserRepository();
        }
        public async Task<User> CreateUser(User user)
        {
            var newUser= await _userRepository.CreateUser(user);
            if (newUser != null)
            {
                var usersFromDb = await _userRepository.GetAllUsers();
                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetUsersInCache(usersFromDb);
                }
            }

            return newUser;
        }

        public async Task DeleteUserById(int id)
        {
            await _userRepository.DeleteUser(id);
            await _cacheManipulation.deleteItemCache(id.ToString());
            
            var usersFromDb = await _userRepository.GetAllUsers();
            if (usersFromDb != null)
            {
                await _cacheManipulation.SetUsersInCache(usersFromDb);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = new List<User>();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("allUsers")))
            {
                var usersFromDb = await _userRepository.GetAllUsers();
                
                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetUsersInCache(usersFromDb);
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
            }
            
            return allUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = new User();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("user_"+id.ToString())))
            {
                var userFromDb = await _userRepository.GetUserById(id);
               
                if (userFromDb != null)
                {
                    await _cacheManipulation.SetUserInCache(userFromDb ,id.ToString());
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
            }
            
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var updateUser= await _userRepository.UpdateUser(user);
            if (updateUser != null)
            {
                await _cacheManipulation.deleteItemCache(user.Id.ToString());
                //await _cacheManipulation.SetUserInCache(updateUser, user.Id.ToString());
                var usersFromDb = await _userRepository.GetAllUsers();

                if (usersFromDb != null)
                {
                    await _cacheManipulation.SetUsersInCache(usersFromDb);
                }
            }
            

            return updateUser;
        }
    }
}
