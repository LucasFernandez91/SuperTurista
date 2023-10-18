using SuperTurista.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var tokenUser = _jwtHelper.GetTokenInfo();
            if (tokenUser == null)
                throw new Exception("Debe iniciar sesión para continuar");

            return tokenUser;
        }
    }
}
