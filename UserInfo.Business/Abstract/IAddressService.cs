using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface IAddressService
    {
        Task<List<AddressDto>> GetAllAddress();
        Task<AddressDto> GetAddressById(int id);
        Task<AddressDto> CreateAddress(AddressDto address);
        Task<AddressDto> UpdateAddress(AddressDto address);
        Task DeleteAddress(int id);
    }
}
