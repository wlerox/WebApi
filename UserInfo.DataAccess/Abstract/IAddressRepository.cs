using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Entities;

namespace UserInfo.DataAccess.Abstract
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAddress();
        Task<Address> GetAddressById(int id);
        Task<Address> CreateAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task DeleteAddress(int id);
    }
}
