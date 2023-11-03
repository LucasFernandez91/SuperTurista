using SuperTurista.Core.DTOs;
using SuperTurista.Core.Mappers;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;

namespace SuperTuriste.Service.Services
{
    public interface IRolService : IBaseService
    {
        Task<List<Rol>> List();
        Task<Rol> GetById(long id);
        Task<SaveRolDTO> Save(SaveRolDTO model);
        Task<bool> Delete(long id);
    }
    public class RolService : BaseService, IRolService
    {
        private readonly IRolRepository _rolRepository;
        public RolService
        (
            IRolRepository RolRepository,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _rolRepository = RolRepository;
        }

        #region Getters

        public async Task<List<Rol>> List()
        {
            return (await _rolRepository.ExecuteQueryAsync()).ToList();
        }

        public async Task<Rol> GetById(long id)
        {
            return (await _rolRepository.ExecuteQueryAsync(x => x.Id == id)).FirstOrDefault() ?? new Rol();
        }
        #endregion

        #region DB Access

        public async Task<SaveRolDTO> Save(SaveRolDTO model)
        {
            if (!Validate(model))
                throw new Exception("Ocurrió un error al intentar guardar el Rol");

            Rol u;

            if (model.Id == 0)
                u = await Insert(model);
            else
                u = await Update(model);
            await _rolRepository.SaveChanges();
            model.Id = (u?.Id ?? 0);

            return model;
        }
        private async Task<Rol> Update(SaveRolDTO model)
        {
            return await _rolRepository.Update(new RolMapper().MapToRol(model));
        }
        private async Task<Rol> Insert(SaveRolDTO model)
        {
            return await _rolRepository.Add(new RolMapper().MapToRol(model));
        }
        public async Task<bool> Delete(long id)
        {
            var u = await GetById(id);
            return await _rolRepository.SoftDelete(u);
        }
        private bool Validate(SaveRolDTO model)
        {
            return true;
        }
        #endregion
    }
}
