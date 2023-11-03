using SuperTurista.Core.DTOs;
using SuperTurista.Core.Models;

namespace SuperTurista.Core.Mappers
{
    public class RolMapper
    {
        public Rol MapToRol(SaveRolDTO DTO)
        {
            return new Rol()
            {
                Id = DTO.Id,
                Nombre = DTO.Nombre,
                Codigo = DTO.Codigo,
                Activo = DTO.Activo
            };
        }
        public RolDTO MapToDto(Rol entity)
        {
            return new RolDTO()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Codigo = entity.Codigo,
                Activo = entity.Activo
            };
        }
    }
}
