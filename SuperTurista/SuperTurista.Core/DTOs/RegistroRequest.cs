using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.Core.DTOs
{
    public class RegistroRequest
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegistroResponse
    {
        public UsuarioDTO Usuario { get; set; }
        public JwtTokenDto Token { get; set; }
    }
}
