using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Abstract
{
    public interface IAddressRepository
    {
        Task<List<AddressDto>> GetAllAddress();
        Task<AddressDto> GetAddressById(int id);
        Task<AddressDto> CreateAddress(AddressDto address);
        Task<AddressDto> UpdateAddress(AddressDto address);
        Task DeleteAddress(int id);
    }
}
