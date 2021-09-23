using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;

namespace UserInfo.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _DbContext;
        public UserRepository(UserDbContext context)
        {
            _DbContext = context;
        }
        public async Task<User> CreateUser(User newuser)
        {

            _DbContext.Users.Add(newuser);
            await _DbContext.SaveChangesAsync();
            return newuser;

        }

        public async Task DeleteUser(int id)
        {
            var deleteUser = await GetUserById(id);
            if (deleteUser != null)
            {
                _DbContext.Users.Remove(deleteUser);
                await _DbContext.SaveChangesAsync();
            }
        }


        public async Task<List<User>> GetAllUsers()
        {

            var users = await _DbContext.Users.Include(a => a.Address)
                                            .ThenInclude(g => g.Geo)
                                            .Include(c => c.Company)
                                            .ToListAsync();
            if (users != null)
            {
                return users;
            }
            else
            {
                return null;
            }



        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _DbContext.Users.Include(a => a.Address)
                                         .ThenInclude(g => g.Geo)
                                         .Include(c => c.Company)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public async Task<User> UpdateUser(User user)
        {
            if (await GetUserById(user.Id) != null)
            {
                _DbContext.Users.Update(user);
                await _DbContext.SaveChangesAsync();
            }
            else
            {
                user = null;
            }
            return user;

        }

    }
}
