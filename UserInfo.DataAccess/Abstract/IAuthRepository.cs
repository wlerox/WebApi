using System;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Abstract
{
    public interface IAuthRepository
    {
        Task<AdminSetDto> Login(AdminDto admin);
        Task<AdminSetDto> ChangeUserPassword(string username,string password,string new_password);
        Task<AdminSetDto> ChangeUserRole(string username, string password, string role);
    }
}
