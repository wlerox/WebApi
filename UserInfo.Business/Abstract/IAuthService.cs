using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Business.Abstract
{
    public interface IAuthService
    {
        bool Login(string username,string password);
    }
}
