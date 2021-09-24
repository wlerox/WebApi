using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;

namespace UserInfo.Business.Concrete
{
    public class GeolocationService : IGeolocationService
    {
        private IGeolocationRepository _geolocationRepository;
        private readonly IDistributedCache _distributedCache;
        private CacheManipulation _cacheManipulation;
        public GeolocationService(IGeolocationRepository geolocationRepository, IDistributedCache distributedCache)
        {
            _geolocationRepository = geolocationRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = new CacheManipulation(_distributedCache);
        }
        public async Task<Geolocation> CreateGeolocation(Geolocation geolocation)
        {
            var newGeolocation = await _geolocationRepository.CreateGeolocation(geolocation);
            return newGeolocation;
        }

        public async Task DeleteGeolocation(int id)
        {
            await _geolocationRepository.DeleteGeolocation(id);
        }

        public async Task<List<Geolocation>> GetAllGeolocation()
        {
            return await _geolocationRepository.GetAllGeolocation();
        }

        public async Task<Geolocation> GetGeolocationById(int id)
        {
            return await _geolocationRepository.GetGeolocationById(id);
        }

        public async Task<Geolocation> UpdateGeolocation(Geolocation geolocation)
        {
            var updateGeolocation = await _geolocationRepository.UpdateGeolocation(geolocation);
            return updateGeolocation;
        }
    }
}
