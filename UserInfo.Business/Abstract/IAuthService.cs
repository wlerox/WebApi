
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface IAuthService
    {
        Task<string> Login(AdminDto admin);
        Task<AdminSetDto> ChangeUserPassword(string username, string password, string new_password);
        Task<AdminSetDto> ChangeUserRole(string username, string password, string role);
    }
}
