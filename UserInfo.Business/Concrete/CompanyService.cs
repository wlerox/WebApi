using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IDistributedCache _distributedCache;
        private readonly ICacheManipulation<CompanyDto> _cacheManipulation;
        public CompanyService(ICompanyRepository companyRepository,IDistributedCache distributedCache,ICacheManipulation<CompanyDto> cacheManipulation)
        {
            _companyRepository = companyRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = cacheManipulation;
            //_userRepository = new UserRepository();
        }
        public async Task<CompanyDto> CreateCompany(CompanyDto company)
        {
            var newCompany = await _companyRepository.CreateCompany(company);
            if (newCompany != null)
            {
                await _cacheManipulation.deleteItemCache("allCompany");
            }
            return newCompany;
        }

        public async Task DeleteCompany(int id)
        {
            await _companyRepository.DeleteCompany(id);
            await _cacheManipulation.deleteItemCache("company_" + id.ToString());
            await _cacheManipulation.deleteItemCache("allCompany");
        }

        public async Task<List<CompanyDto>> GetAllCompany()
        {
            var allCompany = new List<CompanyDto>();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("allCompany")))
            {
                var companiesFromDb = await _companyRepository.GetAllCompany();

                if (companiesFromDb != null)
                {
                    await _cacheManipulation.SetAllOfItemsInCache(companiesFromDb, "allCompany");
                    allCompany = companiesFromDb;
                }
                else
                {
                    allCompany = null;
                }
            }
            else
            {
                allCompany = await _cacheManipulation.GetAllOfItemsFromCache("allCompany");
            }

            return allCompany;
        }

        public async Task<CompanyDto> GetCompanyById(int id)
        {
            var company = new CompanyDto();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("company_" + id.ToString())))
            {
                var companyFromDb = await _companyRepository.GetCompanyById(id);

                if (companyFromDb != null)
                {
                    await _cacheManipulation.SetItemInCache(companyFromDb, "company_" + id.ToString());
                    company = companyFromDb;
                }
                else
                {
                    company = null;
                }
            }
            else
            {
                company = await _cacheManipulation.GetItemFromCache("company_" + id.ToString());
            }

            return company;
        }

        public async Task<CompanyDto> UpdateCompany(CompanyDto company)
        {
            var updateCompany = await _companyRepository.UpdateCompany(company);
            if(updateCompany != null)
            {
                await _cacheManipulation.deleteItemCache("company_" + updateCompany.Id.ToString());
            }
            
            return updateCompany;
        }
    }
}
