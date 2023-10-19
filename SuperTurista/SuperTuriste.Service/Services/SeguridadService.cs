using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SuperTurista.Core.DTOs;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Mappers;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;

namespace SuperTuriste.Service.Services
{
    public interface ISeguridadService : IBaseService
    {
        Task<LoginResponse> Login(LoginRequest request);
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
                throw new Exception("Su usuario se encuentra dado de baja. Por favor comuníquese con el administrador del sistema");

            JwtTokenDto token = await jwtHelper.GenerateToken(loggedUser);
            result.Usuario = new UsuarioMapper().MapToDto(loggedUser);
            result.Token = token;

            return result;
        }
    }
}
