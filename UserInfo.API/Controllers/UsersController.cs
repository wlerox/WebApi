using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.API.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        /// <summary>
        /// Constracter is
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }
        /// <summary>
        /// Get User By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();

        }
        /// <summary>
        /// Delete user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userService.GetUserById(id) != null)
            {
                await _userService.DeleteUserById(id);
                return Ok();
            }
            return NotFound();

        }

        /// <summary>
        /// Create New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewUser([FromBody] UserDto user)
        {
            var newUser = await _userService.CreateUser(user);
            return Ok(newUser);
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            var updateUser = await _userService.UpdateUser(user);
            if (updateUser != null)
            {
                return Ok(updateUser);
            }
            return NotFound();
        }
    }
}
