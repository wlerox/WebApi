using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Concrete
{
    public class GeolocationRepository : IGeolocationRepository
    {
        private readonly UserDbContext _DbContext;
        private readonly IMapper _mapper;
        
        public GeolocationRepository(UserDbContext context,IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }
        public async Task<GeolocationDto> CreateGeolocation(GeolocationDto geolocation)
        {
            var createGeolocation = _mapper.Map<Geolocation>(geolocation);
            _DbContext.Geolocations.Add(createGeolocation);
            await _DbContext.SaveChangesAsync();
            return await GetGeolocationById(createGeolocation.Id);
        }

        public async Task DeleteGeolocation(int id)
        {
            var deleteGeolocation = await GetGeolocationById(id);
            if (deleteGeolocation != null)
            {
                var geolocation = _mapper.Map<Geolocation>(deleteGeolocation);
                _DbContext.Geolocations.Remove(geolocation);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<GeolocationDto>> GetAllGeolocation()
        {
            var getGeolocationList = await _DbContext.Geolocations.ToListAsync();
            if (getGeolocationList != null)
            {
                var geolocationList = _mapper.Map<List<GeolocationDto>>(getGeolocationList);
                return geolocationList;
            }
            else
            {
                return null;
            }
        }

        public async Task<GeolocationDto> GetGeolocationById(int id)
        {
            var getGeolocation = await _DbContext.Geolocations.AsNoTracking().FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (getGeolocation != null)
            {
                var geolocation = _mapper.Map<GeolocationDto>(getGeolocation);
               /* var geolocationDto = new GeolocationDto
                {
                    Id = geolocation.Id,
                    Lat = geolocation.Lat,
                    Lng = geolocation.Lng

                };*/
                return geolocation;
            }
            else
            {
                return null;
            }
        }

        public async Task<GeolocationDto> UpdateGeolocation(GeolocationDto geolocation)
        {
            if (await GetGeolocationById(geolocation.Id) != null)
            {
                var updateGeolocation = _mapper.Map<Geolocation>(geolocation);
                _DbContext.Geolocations.Update(updateGeolocation);
                await _DbContext.SaveChangesAsync();
                geolocation = await GetGeolocationById(updateGeolocation.Id);
            }
            else
            {
                geolocation = null;
            }
            return geolocation;
        }
    }
}
