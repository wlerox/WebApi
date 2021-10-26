using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service) {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserAuthDto admin)
        {
            var loginUser = await _service.Login(admin);
            if (loginUser == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok(loginUser);
        }
        /// <summary>
        /// Chance user password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="new_Password"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpPut("ChanceUserPassword")]
        public async Task<IActionResult> ChanceUserPassword(string username, string password, string new_Password)
        {
            var user= await _service.ChangeUserPassword(username, password, new_Password);
            if (user == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok();
        }
        /// <summary>
        /// Change User Role (Role id = Admin(role_id= 1) or User(role_id= 2) ) Admin = full authority, User = limited authority
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole(string username, string password,int role_id)
        {
            var user = await _service.ChangeUserRole(username, password, role_id);
            if (user == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok(user);
        }
    }
}
