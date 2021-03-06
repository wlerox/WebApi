using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.API.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        /// <summary>
        /// Constracter is
        /// </summary>
        /// <param name="companyService"></param>
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        /// <summary>
        /// Get all Company
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            var users = await _companyService.GetAllCompany();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }
        /// <summary>
        /// Get Company By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            if (company != null)
            {
                return Ok(company);
            }
            return NotFound();

        }
        /// <summary>
        /// Delete Company by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (await _companyService.GetCompanyById(id) != null)
            {
                await _companyService.DeleteCompany(id);
                return Ok();
            }
            return NotFound();

        }

        /// <summary>
        /// Create New Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewCompany([FromBody] CompanyDto company)
        {
            var newCompany = await _companyService.CreateCompany(company);
            return Ok(newCompany);
        }
        /// <summary>
        /// Update Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyDto company)
        {

            var updateCompany = await _companyService.UpdateCompany(company);
            if (updateCompany != null)
            {
                return Ok(updateCompany);
            }
            return NotFound();
        }
    }
}

