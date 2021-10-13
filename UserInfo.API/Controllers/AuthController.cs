using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public AuthController( IAuthService service) { 
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]AdminDto admin)
        {
            var loginUser =await _service.Login(admin);
            if(loginUser == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok(loginUser);
        }
    }
}
