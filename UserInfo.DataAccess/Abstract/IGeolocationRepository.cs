using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Entities;

namespace UserInfo.DataAccess.Abstract
{
    public interface IGeolocationRepository
    {
        Task<List<Geolocation>> GetAllGeolocation();
        Task<Geolocation> GetGeolocationById(int id);
        Task<Geolocation> CreateGeolocation(Geolocation geolocation);
        Task<Geolocation> UpdateGeolocation(Geolocation geolocation);
        Task DeleteGeolocation(int id);
    }
}
