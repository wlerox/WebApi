using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.DataAccess.Abstract
{
    public interface IJwtTokenHandler
    {
        string GetJwtToken(string username);
    }
}
