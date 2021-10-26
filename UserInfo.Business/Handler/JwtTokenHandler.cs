using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserInfo.Business.Abstract;
using UserInfo.Entities.DtoModel;
using UserInfo.Entities.Enum;

namespace UserInfo.Business.Handler
{
    public class JwtTokenHandler:IJwtTokenHandler
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetJwtToken(UserSecurityDto user)
        {
            var role = Enum.GetName(typeof(UserType), user.RoleId);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration["JwtAuth:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,role)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
