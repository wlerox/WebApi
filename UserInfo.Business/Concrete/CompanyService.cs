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
            return newCompany;
        }

        public async Task DeleteCompany(int id)
        {
            await _companyRepository.DeleteCompany(id);
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await _companyRepository.GetAllCompany();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyRepository.GetCompanyById(id);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            var updateCompany = await _companyRepository.UpdateCompany(company);
            return updateCompany;
        }
    }
}
