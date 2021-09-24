using Microsoft.EntityFrameworkCore;
using UserInfo.DataAccess.Abstract;

namespace UserInfo.DataAccess.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserDbContext _context;
        public AuthRepository(UserDbContext context)
        {
            _context = context;
        }
        public bool Login(string username, string password)
        {
            
                var superUser = _context.Administrators.FirstOrDefaultAsync(x => x.UserName == username);
                
                if (superUser.Result == null)
                {
                    return false;
                }
                else
                {
                    if (superUser.Result.UserName == username && superUser.Result.Password == password)
                        return true;
                    else
                        return false;
                }
                
            
            //return username.Equals("admin") && password.Equals("123");
        }
    }
}
