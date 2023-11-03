using SuperTurista.Core.DTOs;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Models;
using System;

namespace SuperTurista.Core.Mappers
{
    public class VehiculoMapper
    {
        public Vehiculo MapToVehiculo(SaveVehiculoDTO DTO)
        {
            return new Vehiculo()
            {
                Id = DTO.Id,
                Titulo = DTO.Titulo,
                Marca = DTO.Marca,
                Modelo = DTO.Modelo,
                Detalle = DTO.Detalle,
                Precio = DTO.Precio,
                EsOferta = DTO.EsOferta,
                PrecioOferta = DTO.PrecioOferta,
                Tipo = DTO.Tipo,
                Activo = DTO.Activo
            };
        }
        public VehiculoDTO MapToDto(Vehiculo entity)
        {
            return new VehiculoDTO()
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Detalle = entity.Detalle,
                Precio = entity.Precio,
                EsOferta = entity.EsOferta,
                PrecioOferta = entity.PrecioOferta,
                Tipo = entity.Tipo,
                Activo = entity.Activo
            };
        }
    }
}
