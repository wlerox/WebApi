using UserInfo.Entities.DtoModel;

namespace UserInfo.Business.Abstract
{
    public interface IJwtTokenHandler
    {
        string GetJwtToken(UserSecurityDto user);
    }
}
