
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface IAuthService
    {
        Task<string> Login(UserAuthDto admin);
        Task<UserSecurityDto> ChangeUserPassword(string username, string password, string new_password);
        Task<UserSecurityDto> ChangeUserRole(string username, string password, int role_id);
    }
}
