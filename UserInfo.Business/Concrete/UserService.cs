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
        private IUserRepository _userRepository;
        private readonly IDistributedCache _distributedCache;
        private ICacheManipulation _cacheManipulation;
        public UserService(IUserRepository userRepository,IDistributedCache distributedCache,ICacheManipulation cacheManipulation)
        {
            _userRepository = userRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = cacheManipulation;
            //_userRepository = new UserRepository();
        }
        public async Task<UserDto> CreateUser(UserDto user)
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

        public async Task<List<UserDto>> GetAllUsers()
        {
            var allUsers = new List<UserDto>();
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

        public async Task<UserDto> GetUserById(int id)
        {
            var user = new UserDto();
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

        public async Task<UserDto> UpdateUser(UserDto user)
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
