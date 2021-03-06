using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.API.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationsController : ControllerBase
    {
        private readonly IGeolocationService _geolocationService;
        /// <summary>
        /// Constracter is
        /// </summary>
        /// <param name="geolocationService"></param>
        public GeolocationsController(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewGeo([FromBody] GeolocationDto geolocation)
        {
            var newGeo = await _geolocationService.CreateGeolocation(geolocation);
            return Ok(newGeo);
        }
        /// <summary>
        /// Update Geolocation
        /// </summary>
        /// <param name="geolocation"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateGeo([FromBody] GeolocationDto geolocation)
        {
            var updateGeo = await _geolocationService.UpdateGeolocation(geolocation);
            if (updateGeo != null)
            {
                return Ok(updateGeo);
            }
            return NotFound();
        }
    }
}

