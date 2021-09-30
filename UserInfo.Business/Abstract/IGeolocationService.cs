using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface IGeolocationService
    {
        Task<List<GeolocationDto>> GetAllGeolocation();
        Task<GeolocationDto> GetGeolocationById(int id);
        Task<GeolocationDto> CreateGeolocation(GeolocationDto geolocation);
        Task<GeolocationDto> UpdateGeolocation(GeolocationDto geolocation);
        Task DeleteGeolocation(int id);
    }
}
