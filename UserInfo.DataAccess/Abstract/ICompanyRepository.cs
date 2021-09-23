using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Entities;

namespace UserInfo.DataAccess.Abstract
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompany();
        Task<Company> GetCompanyById(int id);
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task DeleteCompany(int id);
    }
}
