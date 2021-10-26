using System.Threading.Tasks;
using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;
using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Concrete
{
    public class AuthService : IAuthService
    {
        public IAuthRepository _authRepository;
        private readonly IJwtTokenHandler _tokenHandler;
        public AuthService(IAuthRepository authRepository, IJwtTokenHandler tokenHandler)
        {
            _authRepository = authRepository;
            _tokenHandler = tokenHandler;
        }
        public async Task<string> Login(UserAuthDto admin)
        {
            var user = await _authRepository.Login(admin);
            if (user == null)
            {
                return null;
            }
            var token = _tokenHandler.GetJwtToken(user);
            return token;
        }

        public async Task<UserSecurityDto> ChangeUserPassword(string username, string password, string new_password)
        {
            var user= await _authRepository.ChangeUserPassword(username, password, new_password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<UserSecurityDto> ChangeUserRole(string username, string password, int role_id)
        {
            return  await _authRepository.ChangeUserRole(username, password, role_id);
        }
    }
}
