using UserInfo.Business.Abstract;
using UserInfo.DataAccess.Abstract;

namespace UserInfo.Business.Concrete
{
    public class AuthService : IAuthService
    {
        public IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public bool Login(string username, string password)
        {
           return _authRepository.Login(username, password);
        }
    }
}
