using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.DataAccess.Abstract
{
    public interface IAuthRepository
    {
        bool Login(string username, String password);
    }
}
