using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.DTOs
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Clave { get; set; }
    }

    public class LoginResponse
    {
        public UsuarioDTO Usuario { get; set; }
        public bool DebeCambiarClave { get; set; }
        public JwtTokenDto Token { get; set; }
        public string CognitoChallenge { get; set; }
    }

    public class UserTokenInfoDto
    {
        public long UserId { get; set; }
        public long PersonId { get; set; }
        public string UserName { get; set; }
    }

    public class JwtTokenDto
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
