using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class GeolocationService : IGeolocationService

    {
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly IDistributedCache _distributedCache;
        private readonly ICacheManipulation<GeolocationDto> _cacheManipulation;
        public GeolocationService(IGeolocationRepository geolocationRepository,IDistributedCache distributedCache,ICacheManipulation<GeolocationDto> cacheManipulation)
        {
            _geolocationRepository = geolocationRepository;
            _distributedCache = distributedCache;
            _cacheManipulation = cacheManipulation;
        }
        public async Task<GeolocationDto> CreateGeolocation(GeolocationDto geolocation)
        {
            var newGeolocation = await _geolocationRepository.CreateGeolocation(geolocation);
            if (newGeolocation != null)
            {
                await _cacheManipulation.deleteItemCache("allGeolocation");
            }
            return newGeolocation;
        }

        public async Task DeleteGeolocation(int id)
        {
            await _geolocationRepository.DeleteGeolocation(id);
            await _cacheManipulation.deleteItemCache("geolocation_"+id.ToString());
            await _cacheManipulation.deleteItemCache("allGeolocation");
        }

        public async Task<List<GeolocationDto>> GetAllGeolocation()
        {
            var allGeolocations = new List<GeolocationDto>();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("allGeolocation")))
            {
                var geolocationsFromDb = await _geolocationRepository.GetAllGeolocation();

                if (geolocationsFromDb != null)
                {
                    await _cacheManipulation.SetAllOfItemsInCache(geolocationsFromDb, "allGeolocation");
                    allGeolocations = geolocationsFromDb;
                }
                else
                {
                    allGeolocations = null;
                }

            }
            else
            {
                allGeolocations = await _cacheManipulation.GetAllOfItemsFromCache("allGeolocation");
            }

            return allGeolocations;
        }

        public async Task<GeolocationDto> GetGeolocationById(int id)
        {
            var geolocation = new GeolocationDto();
            if (String.IsNullOrEmpty(await _distributedCache.GetStringAsync("geolocation_" + id.ToString())))
            {
                var geolocationFromDb = await _geolocationRepository.GetGeolocationById(id);

                if (geolocationFromDb != null)
                {
                    await _cacheManipulation.SetItemInCache(geolocationFromDb, "geolocation_" + id.ToString());
                    geolocation = geolocationFromDb;
                }
                else
                {
                    geolocation = null;
                }
            }
            else
            {
                geolocation = await _cacheManipulation.GetItemFromCache("geolocation_" + id.ToString());
            }

            return geolocation;
        }

        public async Task<GeolocationDto> UpdateGeolocation(GeolocationDto geolocation)
        {
            var updateGeolocation = await _geolocationRepository.UpdateGeolocation(geolocation);
            if(updateGeolocation != null)
            {
                await _cacheManipulation.deleteItemCache("geolocation_" + updateGeolocation.Id.ToString());
            }
            
            return updateGeolocation;
        }
    }
}
