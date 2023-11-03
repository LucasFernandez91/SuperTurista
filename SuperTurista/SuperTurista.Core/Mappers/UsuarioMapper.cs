using SuperTurista.Core.DTOs;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Models;

namespace SuperTurista.Core.Mappers
{
    public class UsuarioMapper
    {
        public Usuario MapToUsuario(SaveUsuarioDTO DTO)
        {
            return new Usuario()
            {
                Id = DTO.Id,
                Login = DTO.Login,
                Email = DTO.Email,
                PasswordHash = EncryptHelper.CreatePasswordHash(DTO.Password),
                Activo = true
            };
        }
        public UsuarioDTO MapToDto(Usuario entity)
        {
            return new UsuarioDTO()
            {
                Login = entity.Login,
                Email = entity.Email,
            };
        }
        public Usuario MapRegistroToNewUsuario(RegistroRequest request)
        {
            return new Usuario()
            {
                Login = request.Login,
                Email = request.Email,
                PasswordHash = EncryptHelper.CreatePasswordHash(request.Password),
                Persona = new Persona
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Telefono = request.Telefono,
                },
                Activo = false
            };
        }
    }
}
