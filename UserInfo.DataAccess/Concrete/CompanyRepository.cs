using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Concrete
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly UserDbContext _DbContext;
        private readonly IMapper _mapper;
        public CompanyRepository(UserDbContext context, IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }
        public async Task<CompanyDto> CreateCompany(CompanyDto company)
        {
            var createCompany = _mapper.Map<Company>(company);
            _DbContext.Companies.Add(createCompany);
            await _DbContext.SaveChangesAsync();
            return await GetCompanyById(createCompany.Id);
        }

        public async Task DeleteCompany(int id)
        {
            var deleteCompany = await GetCompanyById(id);
            if (deleteCompany != null)
            {
                var company = _mapper.Map<Company>(deleteCompany);
                _DbContext.Companies.Remove(company);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CompanyDto>> GetAllCompany()
        {
            var getCompanyList = await _DbContext.Companies.ToListAsync();
            if (getCompanyList != null)
            {
                var companyList = _mapper.Map<List<CompanyDto>>(getCompanyList);
                return companyList;
            }
            else
            {
                return null;
            }
        }

        public async Task<CompanyDto> GetCompanyById(int id)
        {
            var getCompany = await _DbContext.Companies.AsNoTracking().FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (getCompany != null)
            {
                var company = _mapper.Map<CompanyDto>(getCompany);
                return company;
            }
            else
            {
                return null;
            }
        }

        public async Task<CompanyDto> UpdateCompany(CompanyDto company)
        {
            if (await GetCompanyById(company.Id) != null)
            {
                var updateCompany = _mapper.Map<Company>(company);
                _DbContext.Companies.Update(updateCompany);
                await _DbContext.SaveChangesAsync();
                company = await GetCompanyById(updateCompany.Id);
            }
            else
            {
                company = null;
            }
            return company;
        }
    }
}
