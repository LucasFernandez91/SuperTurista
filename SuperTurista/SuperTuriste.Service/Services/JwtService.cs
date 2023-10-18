using SuperTurista.Core.DTOs;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTuriste.Service.Services
{
    public class JwtService
    {
        private readonly ISystemParametersRepository _parametroSistemaRepository;
        private readonly JwtHelper _jwtHelper;
        public JwtService(
            ISystemParametersRepository parametroSistemaRepository,
            JwtHelper jwtHelper
        )
        {
            _parametroSistemaRepository = parametroSistemaRepository;
            _jwtHelper = jwtHelper;
        }
        public async Task<JwtTokenDto> GenerateToken(Usuario usuario)
        {
            var sessionTimeoutValue = (await _parametroSistemaRepository.ExecuteSelectableQueryAsync(s => s.Value, f => f.Code == "TimeoutSesion"))?.FirstOrDefault();
            int.TryParse(sessionTimeoutValue, out var sessionTimeout);
            if (sessionTimeout <= 0) sessionTimeout = 15;

            return GenerateToken(usuario, sessionTimeout);
        }
        public JwtTokenDto GenerateToken(Usuario usuario, int expireMinutes)
        {
            return _jwtHelper.GenerateToken(usuario, expireMinutes);
        }
        public UserTokenInfoDto GetTokenInfo()
        {
            return _jwtHelper.GetTokenInfo();
        }
    }
}
