using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

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

        public async Task<AdminSetDto> ChangeUserPassword(string username, string password, string new_password)
        {
            var user = await _context.Administrators.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                user.Password = new_password;
                _context.Administrators.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<AdminSetDto>(user);
            }

            return null;
            //throw new System.NotImplementedException();
        }

        public async Task<AdminSetDto> ChangeUserRole(string username, string password, string role)
        {
            var user = await _context.Administrators.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                user.Role = role;
                _context.Administrators.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<AdminSetDto>(user);
            }

            return null;
        }

        public async  Task<AdminSetDto> Login(AdminDto admin)
        {

            var user =await _context.Administrators.FirstOrDefaultAsync(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (user == null)
            {
                return null;
            }
            var userDto = _mapper.Map<AdminSetDto>(user);

            return userDto;
            //return username.Equals("admin") && password.Equals("123");
        }
    }
}
