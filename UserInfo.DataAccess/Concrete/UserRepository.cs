
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities;
using UserInfo.Entities.DtoModel;

namespace UserInfo.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _DbContext;
        private readonly IMapper _mapper;
        public UserRepository(UserDbContext context, IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUser(UserDto newuser)
        {
            var userCreate = _mapper.Map<User>(newuser);
            _DbContext.Users.Add(userCreate);
            await _DbContext.SaveChangesAsync();
            return await GetUserById(userCreate.Id);

        }

        public async Task DeleteUser(int id)
        {
            var deleteUser = await GetUserById(id);
            if (deleteUser != null)
            {
                var user = _mapper.Map<User>(deleteUser);
                _DbContext.Users.Remove(user);
                await _DbContext.SaveChangesAsync();
            }
        }


        public async Task<List<UserDto>> GetAllUsers()
        {

            var getUserList = await _DbContext.Users.Include(a => a.Address)
                                            .ThenInclude(g => g.Geo)
                                            .Include(c => c.Company)
                                            .ToListAsync();
            if (getUserList != null)
            {
                var userList = _mapper.Map<List<UserDto>>(getUserList);
                return userList;
            }
            else
            {
                return null;
            }



        }

        public async Task<UserDto> GetUserById(int id)
        {
            var getUser = await _DbContext.Users.Include(a => a.Address)
                                         .ThenInclude(g => g.Geo)
                                         .Include(c => c.Company)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(b => b.Id.Equals(id));
            if (getUser != null)
            {
                var user = _mapper.Map<UserDto>(getUser);
                /*var userDto= new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    Phone = user.Phone,
                    AddressId = user.AddressId,
                    Email = user.Email,
                    Website = user.Website,
                    CompanyId = user.CompanyId
                };*/
                return user;
            }
            else
            {
                return null;
            }

        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            if (await GetUserById(user.Id) != null)
            {
                var updateUser = _mapper.Map<User>(user);
                _DbContext.Users.Update(updateUser);
                await _DbContext.SaveChangesAsync();
                user = await GetUserById(updateUser.Id);
            }
            else
            {
                user = null;
            }
            return user;

        }

    }
}
