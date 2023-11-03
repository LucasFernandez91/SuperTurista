using SuperTurista.Core.DTOs;
using SuperTurista.Core.Mappers;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;
using System.Text.RegularExpressions;

namespace SuperTuriste.Service.Services
{
    public interface IVehiculoService : IBaseService
    {
        Task<List<Vehiculo>> List();
        Task<Vehiculo> GetById(long id);
        Task<SaveVehiculoDTO> Save(SaveVehiculoDTO model);
        Task<bool> Delete(long id);
    }
    public class VehiculoService : BaseService, IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        public VehiculoService
        (
            IVehiculoRepository VehiculoRepository,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _vehiculoRepository = VehiculoRepository;
        }

        #region Getters

        public async Task<List<Vehiculo>> List()
        {
            return (await _vehiculoRepository.ExecuteQueryAsync()).ToList();
        }

        public async Task<Vehiculo> GetById(long id)
        {
            return (await _vehiculoRepository.ExecuteQueryAsync(x => x.Id == id)).FirstOrDefault() ?? new Vehiculo();
        }
        #endregion

        #region DB Access

        public async Task<SaveVehiculoDTO> Save(SaveVehiculoDTO model)
        {
            if (!Validate(model))
                throw new Exception("Ocurrió un error al intentar guardar el Vehiculo");

            Vehiculo u;

            if (model.Id == 0)
                u = await Insert(model);
            else
                u = await Update(model);
            await _vehiculoRepository.SaveChanges();
            model.Id = (u?.Id ?? 0);

            return model;
        }
        private async Task<Vehiculo> Update(SaveVehiculoDTO model)
        {
            return await _vehiculoRepository.Update(new VehiculoMapper().MapToVehiculo(model));
        }
        private async Task<Vehiculo> Insert(SaveVehiculoDTO model)
        {
            return await _vehiculoRepository.Add(new VehiculoMapper().MapToVehiculo(model));
        }
        public async Task<bool> Delete(long id)
        {
            var u = await GetById(id);
            return await _vehiculoRepository.SoftDelete(u);
        }
        private bool Validate(SaveVehiculoDTO model)
        {
            return true;
        }
        #endregion
    }
}
