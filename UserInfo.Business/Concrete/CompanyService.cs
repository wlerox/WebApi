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
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;
        private readonly IDistributedCache _distributedCache;
        private CacheManipulation _cacheManipulation;
        public CompanyService(ICompanyRepository companyRepository, IDistributedCache distributedCache)
        {
            _companyRepository = companyRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = new CacheManipulation(_distributedCache);
            //_userRepository = new UserRepository();
        }
        public async Task<Company> CreateCompany(Company company)
        {
            var newCompany = await _companyRepository.CreateCompany(company);
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

            return newCompany;
        }

        public async Task DeleteCompany(int id)
        {
            await _companyRepository.DeleteCompany(id);
            //await _cacheManipulation.deleteItemCache(id.ToString());

            /*var usersFromDb = await _addressRepository.GetAllAddress();
            if (usersFromDb != null)
            {
                await _cacheManipulation.SetUsersInCache(usersFromDb);
            }*/
        }

        public async Task<List<Company>> GetAllCompany()
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

            return await _companyRepository.GetAllCompany();
        }

        public async Task<Company> GetCompanyById(int id)
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

            return await _companyRepository.GetCompanyById(id);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            var updateCompany = await _companyRepository.UpdateCompany(company);
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


            return updateCompany;
        }
    }
}
