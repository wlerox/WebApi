using System;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Abstract
{
    public interface IAuthRepository
    {
        Task<string> Login(AdminDto admin);
    }
}
