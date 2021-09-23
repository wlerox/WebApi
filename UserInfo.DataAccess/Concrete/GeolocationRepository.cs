using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;

namespace UserInfo.DataAccess.Concrete
{
    public class GeolocationRepository : IGeolocationRepository
    {
        private readonly UserDbContext _DbContext;
        public GeolocationRepository(UserDbContext context)
        {
            _DbContext = context;
        }
        public async Task<Geolocation> CreateGeolocation(Geolocation geolocation)
        {
            _DbContext.Geolocations.Add(geolocation);
            await _DbContext.SaveChangesAsync();
            return geolocation;
        }

        public async Task DeleteGeolocation(int id)
        {
            var deleteGeolocation = await GetGeolocationById(id);
            if (deleteGeolocation != null)
            {
                _DbContext.Geolocations.Remove(deleteGeolocation);
                await _DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Geolocation>> GetAllGeolocation()
        {
            var geolocation = await _DbContext.Geolocations.ToListAsync();
            if (geolocation != null)
            {
                return geolocation;
            }
            else
            {
                return null;
            }
        }

        public async Task<Geolocation> GetGeolocationById(int id)
        {
            var geolocation = await _DbContext.Geolocations.AsNoTracking().FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (geolocation != null)
            {
                return geolocation;
            }
            else
            {
                return null;
            }
        }

        public async Task<Geolocation> UpdateGeolocation(Geolocation geolocation)
        {
            if (await GetGeolocationById(geolocation.Id) != null)
            {
                _DbContext.Geolocations.Update(geolocation);
                //_DbContext.Entry(Geolocation).State = EntityState.Detached;
                //_DbContext.Entry<Geolocation>(geolocation).State = EntityState.Detached;
                await _DbContext.SaveChangesAsync();
            }
            else
            {
                geolocation = null;
            }
            return geolocation;
        }
    }
}
