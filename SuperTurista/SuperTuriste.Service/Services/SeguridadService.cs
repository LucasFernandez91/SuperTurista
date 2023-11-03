using SuperTurista.Core.DTOs;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Mappers;
using SuperTurista.Core.Models;

namespace SuperTuriste.Service.Services
{
    public interface ISeguridadService : IBaseService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegistroResponse> Register(RegistroRequest request);
    }
    public class SeguridadService : BaseService, ISeguridadService
    {
        private readonly JwtService jwtHelper;
        private readonly IUsuarioService usuarioService;
        public SeguridadService
        (
            IUsuarioService usuarioService,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            this.usuarioService = usuarioService;
            this.jwtHelper = jwtHelper;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.UserName) ||
                string.IsNullOrWhiteSpace(request?.Clave))
                throw new Exception("Debe especificar usuario y clave para iniciar sesión");

            var loggedUser = await usuarioService.GetByLogin(request.UserName);
            if (loggedUser == null || loggedUser.Id <= 0)
                throw new Exception("Verificar usuario y/o clave");

            var result = new LoginResponse();

            if (!string.IsNullOrEmpty(loggedUser.PasswordHash) && !EncryptHelper.VerifyPassword(request.Clave, loggedUser.PasswordHash))
                throw new Exception("Verificar usuario y/o clave");

            if (!loggedUser.Activo)
                throw new Exception("Su usuario no esta activo.");

            JwtTokenDto token = await jwtHelper.GenerateToken(loggedUser);
            result.Usuario = new UsuarioMapper().MapToDto(loggedUser);
            result.Token = token;

            return result;
        }

        public async Task<RegistroResponse> Register(RegistroRequest request)
        {
            if (request.Password != request.ConfirmPassword)
                throw new Exception("Passwords don't match.");

            var newUser = new UsuarioMapper().MapRegistroToNewUsuario(request);

            throw new NotImplementedException();
        }
    }
}
