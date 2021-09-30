using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllCompany();
        Task<CompanyDto> GetCompanyById(int id);
        Task<CompanyDto> CreateCompany(CompanyDto company);
        Task<CompanyDto> UpdateCompany(CompanyDto company);
        Task DeleteCompany(int id);
    }
}
