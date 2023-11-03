using SuperTurista.Core.DTOs;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Models;
using System;

namespace SuperTurista.Core.Mappers
{
    public class AlojamientoMapper
    {
        public Alojamiento MapToAlojamiento(SaveAlojamientoDTO DTO)
        {
            return new Alojamiento()
            {
                Id = DTO.Id,
                Titulo = DTO.Titulo,
                Ubicacion = DTO.Ubicacion,
                Detalle = DTO.Detalle,
                Precio = DTO.Precio,
                EsOferta = DTO.EsOferta,
                PrecioOferta = DTO.PrecioOferta,
                Tipo = DTO.Tipo,
                Activo = DTO.Activo,
            };
        }
        public AlojamientoDTO MapToDto(Alojamiento entity)
        {
            return new AlojamientoDTO()
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Ubicacion = entity.Ubicacion,
                Detalle = entity.Detalle,
                Precio = entity.Precio,
                EsOferta = entity.EsOferta,
                PrecioOferta = entity.PrecioOferta,
                Tipo = entity.Tipo,
                Activo = entity.Activo,
            };
        }
    }
}
