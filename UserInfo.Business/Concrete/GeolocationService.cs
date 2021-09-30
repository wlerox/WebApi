using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class GeolocationService : IGeolocationService
    {
        private IGeolocationRepository _geolocationRepository;
        //private readonly IDistributedCache _distributedCache;
        //private CacheManipulation _cacheManipulation;
        public GeolocationService(IGeolocationRepository geolocationRepository)
        {
            _geolocationRepository = geolocationRepository;
            //_distributedCache = distributedCache;
            //_cacheManipulation = new CacheManipulation(_distributedCache);
        }
        public async Task<GeolocationDto> CreateGeolocation(GeolocationDto geolocation)
        {
            var newGeolocation = await _geolocationRepository.CreateGeolocation(geolocation);
            return newGeolocation;
        }

        public async Task DeleteGeolocation(int id)
        {
            await _geolocationRepository.DeleteGeolocation(id);
        }

        public async Task<List<GeolocationDto>> GetAllGeolocation()
        {
            return await _geolocationRepository.GetAllGeolocation();
        }

        public async Task<GeolocationDto> GetGeolocationById(int id)
        {
            return await _geolocationRepository.GetGeolocationById(id);
        }

        public async Task<GeolocationDto> UpdateGeolocation(GeolocationDto geolocation)
        {
            var updateGeolocation = await _geolocationRepository.UpdateGeolocation(geolocation);
            return updateGeolocation;
        }
    }
}
