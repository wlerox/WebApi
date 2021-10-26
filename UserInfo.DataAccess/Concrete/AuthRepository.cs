using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.DataAccess.Helper;
using UserInfo.Entities.DtoModel;
using UserInfo.Entities.Enum;

namespace UserInfo.DataAccess.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        

        public AuthRepository(UserDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserSecurityDto> ChangeUserPassword(string username, string password, string new_password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username );
            if (user != null)
            {
                if (HashingCrypto.comparePassword(password, user.Password))
                {
                    user.Password = HashingCrypto.hashPassword(new_password);
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<UserSecurityDto>(await GetUserByUserName(username));
                }
            }

            return null;
            //throw new System.NotImplementedException();
        }

        public async Task<UserSecurityDto> ChangeUserRole(string username, string password, int role_id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
            if (user != null)
            {
                if (HashingCrypto.comparePassword(password, user.Password))
                {
                    //user.RoleId=(int)(UserType) Enum.Parse(typeof(UserType),role);
                    user.RoleId = role_id;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<UserSecurityDto>(await GetUserByUserName(username));
                }
                
            }

            return null;
        }

        public async Task<UserSecurityDto> GetUserByUserName(string username)
        {
            var user = await _context.Users.Include(r=>r.Role).SingleOrDefaultAsync(x => x.Username == username);
            return _mapper.Map<UserSecurityDto>(user);
        }

        public async  Task<UserSecurityDto> Login(UserAuthDto loginuser)
        {

            var user =await _context.Users.SingleOrDefaultAsync(x => x.Username == loginuser.UserName);

            if (user != null)
            {
                if (HashingCrypto.comparePassword(loginuser.Password, user.Password))
                {
                    var userDto = _mapper.Map<UserSecurityDto>(user);
                    return userDto;
                }
                return null;
            }
            //var userDto = _mapper.Map<AdminSetDto>(user);
            return null;
            //return username.Equals("admin") && password.Equals("123");
        }
    }
}
