
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface IAuthService
    {
        Task<string> Login(AdminDto admin);
    }
}
