using System;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Abstract
{
    public interface IAuthRepository
    {
        Task<UserSecurityDto> Login(UserAuthDto user);
        Task<UserSecurityDto> ChangeUserPassword(string username,string password,string new_password);
        Task<UserSecurityDto> ChangeUserRole(string username, string password, int role_id);
        Task<UserSecurityDto> GetUserByUserName(String username);
    }
}
