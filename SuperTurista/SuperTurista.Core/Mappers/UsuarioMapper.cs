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
                Nombre = DTO.Nombre,
                Apellido = DTO.Apellido,
                Login = DTO.Login,
                Email = DTO.Email,
                PasswordHash = EncryptHelper.CreatePasswordHash(DTO.Password),
                Telefono = DTO.Telefono,
                Activo = true
            };
        }
        public UsuarioDTO MapToDto(Usuario entity)
        {
            return new UsuarioDTO()
            {
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Login = entity.Login,
                Email = entity.Email,
                Telefono = entity.Telefono,
            };
        }
    }
}
