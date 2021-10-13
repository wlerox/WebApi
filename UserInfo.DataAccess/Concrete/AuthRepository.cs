using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserDbContext _context;
        private readonly IJwtTokenHandler _tokenHandler;

        public AuthRepository(UserDbContext context, IJwtTokenHandler tokenHandler)
        {
            _context = context;
            _tokenHandler = tokenHandler;
        }

        public async  Task<string> Login(AdminDto admin)
        {

            var superUser =await _context.Administrators.FirstOrDefaultAsync(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (superUser == null)
            {
                return null;
            }
            var token =_tokenHandler.GetJwtToken(superUser.UserName);

            return token;
            //return username.Equals("admin") && password.Equals("123");
        }
    }
}
