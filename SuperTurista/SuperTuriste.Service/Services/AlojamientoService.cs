using SuperTurista.Core.DTOs;
using SuperTurista.Core.Mappers;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;
using System.Text.RegularExpressions;

namespace SuperTuriste.Service.Services
{
    public interface IAlojamientoService : IBaseService
    {
        Task<List<Alojamiento>> List();
        Task<Alojamiento> GetById(long id);
        Task<SaveAlojamientoDTO> Save(SaveAlojamientoDTO model);
        Task<bool> Delete(long id);
    }
    public class AlojamientoService : BaseService, IAlojamientoService
    {
        private readonly IAlojamientoRepository _AlojamientoRepository;
        public AlojamientoService
        (
            IAlojamientoRepository AlojamientoRepository,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _AlojamientoRepository = AlojamientoRepository;
        }

        #region Getters

        public async Task<List<Alojamiento>> List()
        {
            return (await _AlojamientoRepository.ExecuteQueryAsync()).ToList();
        }

        public async Task<Alojamiento> GetById(long id)
        {
            return (await _AlojamientoRepository.ExecuteQueryAsync(x => x.Id == id)).FirstOrDefault() ?? new Alojamiento();
        }
       
        #endregion

        #region DB Access

        public async Task<SaveAlojamientoDTO> Save(SaveAlojamientoDTO model)
        {
            if (!Validate(model))
                throw new Exception("Ocurrió un error al intentar guardar el Alojamiento");

            Alojamiento u;

            if (model.Id == 0)
                u = await Insert(model);
            else
                u = await Update(model);
            await _AlojamientoRepository.SaveChanges();
            model.Id = (u?.Id ?? 0);

            return model;
        }
        private async Task<Alojamiento> Update(SaveAlojamientoDTO model)
        {
            return await _AlojamientoRepository.Update(new AlojamientoMapper().MapToAlojamiento(model));
        }
        private async Task<Alojamiento> Insert(SaveAlojamientoDTO model)
        {
            return await _AlojamientoRepository.Add(new AlojamientoMapper().MapToAlojamiento(model));
        }
        public async Task<bool> Delete(long id)
        {
            var u = await GetById(id);
            return await _AlojamientoRepository.SoftDelete(u);
        }
        private bool Validate(SaveAlojamientoDTO model)
        {
            return true;
        }
        #endregion
    }
}
