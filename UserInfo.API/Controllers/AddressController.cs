using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.API.Controllers
{
    [Authorize(Roles ="Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        /// <summary>
        /// Constracter is
        /// </summary>
        /// <param name="addressService"></param>
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        /// <summary>
        /// Get all Address
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            var users = await _addressService.GetAllAddress();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }
        /// <summary>
        /// Get Address By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var user = await _addressService.GetAddressById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();

        }
        /// <summary>
        /// Delete Address by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (await _addressService.GetAddressById(id) != null)
            {
                await _addressService.DeleteAddress(id);
                return Ok();
            }
            return NotFound();

        }

        /// <summary>
        /// Create New Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAddress([FromBody] AddressDto address)
        {
            var newAddres = await _addressService.CreateAddress(address);
            return Ok(newAddres);
        }
        /// <summary>
        /// Update Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressDto address)
        {
            var updateAddress = await _addressService.UpdateAddress(address);
            if (updateAddress != null)
            {
                return Ok(updateAddress);
            }
            return NotFound();
        }
    }
}

