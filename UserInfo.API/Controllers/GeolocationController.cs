using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.Entities;

namespace UserInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationsController : ControllerBase
    {
        private IGeolocationService _geolocationService;
        //private readonly IDistributedCache _distributedCache;
        /// <summary>
        /// Constracter is
        /// </summary>
        /// <param name="geolocationService"></param>
        /// <param name="distributedCache"></param>
        public GeolocationsController(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
            //_distributedCache = distributedCache;
            //_userService = new UserManager();
        }
        /// <summary>
        /// Get all Geolocation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllGeo()
        {
            var geolocations = await _geolocationService.GetAllGeolocation();
            if (geolocations != null)
            {
                return Ok(geolocations);
            }
            return NotFound();
        }
        /// <summary>
        /// Get Geolocation By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeoById(int id)
        {
            var geolocation = await _geolocationService.GetGeolocationById(id);
            if (geolocation != null)
            {
                return Ok(geolocation);
            }
            return NotFound();

        }
        /// <summary>
        /// Delete Geolocation by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeo(int id)
        {
            if (await _geolocationService.GetGeolocationById(id) != null)
            {
                await _geolocationService.DeleteGeolocation(id);
                return Ok();
            }
            return NotFound();

        }

        /// <summary>
        /// Create New Geolocation
        /// </summary>
        /// <param name="geolocation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewGeo([FromBody] Geolocation geolocation)
        {
            var newGeo = await _geolocationService.CreateGeolocation(geolocation);
            return Ok(newGeo);
        }
        /// <summary>
        /// Update Geolocation
        /// </summary>
        /// <param name="geolocation"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGeo([FromBody] Geolocation geolocation)
        {
            /*if(await _userService.GetUserById(user.Id) != null)
            {
                return Ok(await _userService.UpdateUser(user));
            }*/
            var updateGeo = await _geolocationService.UpdateGeolocation(geolocation);
            if (updateGeo != null)
            {
                return Ok(updateGeo);
            }
            return NotFound();
        }
    }
}

