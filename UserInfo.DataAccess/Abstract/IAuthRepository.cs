using System;

namespace UserInfo.DataAccess.Abstract
{
    public interface IAuthRepository
    {
        bool Login(string username, String password);
    }
}
