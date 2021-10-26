using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> CreateUser(UserSetDto user);
        Task<UserDto> UpdateUser(UserSetDto user);
        Task DeleteUser(int id);
    }
}
