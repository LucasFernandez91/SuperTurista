using SuperTurista.Core.DTOs;

namespace SuperTuriste.Service.Services
{
    public interface IBaseService
    {
        UserTokenInfoDto GetTokenInfo();
    }
    public class BaseService : IBaseService
    {
        private readonly JwtService _jwtHelper;
        public BaseService
        (
            JwtService jwtHelper
        )
        {
            _jwtHelper = jwtHelper;
        }
        public UserTokenInfoDto GetTokenInfo()
        {
            return _jwtHelper.GetTokenInfo() ?? throw new Exception("Must login!");
        }
    }
}
