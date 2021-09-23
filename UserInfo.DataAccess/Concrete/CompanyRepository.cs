using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;

namespace UserInfo.DataAccess.Concrete
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly UserDbContext _DbContext;
        public CompanyRepository(UserDbContext context)
        {
            _DbContext = context;
        }
        public async Task<Company> CreateCompany(Company company)
        {
            _DbContext.Companies.Add(company);
            await _DbContext.SaveChangesAsync();
            return company;
        }

        public async Task DeleteCompany(int id)
        {
            var deleteCompany = await GetCompanyById(id);
            if (deleteCompany != null)
            {
                _DbContext.Companies.Remove(deleteCompany);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Company>> GetAllCompany()
        {
            var company = await _DbContext.Companies.ToListAsync();
            if (company != null)
            {
                return company;
            }
            else
            {
                return null;
            }
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var company = await _DbContext.Companies.AsNoTracking().FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (company != null)
            {
                return company;
            }
            else
            {
                return null;
            }
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            if (await GetCompanyById(company.Id) != null)
            {
                _DbContext.Companies.Update(company);
                await _DbContext.SaveChangesAsync();
            }
            else
            {
                company = null;
            }
            return company;
        }
    }
}
