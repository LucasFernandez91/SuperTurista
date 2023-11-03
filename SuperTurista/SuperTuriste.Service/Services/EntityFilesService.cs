using SuperTurista.Core.DTOs;
using SuperTurista.Core.Mappers;
using SuperTurista.Core.Models;
using SuperTurista.DataAccess.Repository;

namespace SuperTuriste.Service.Services
{
    public interface IEntityFilesService : IBaseService
    {
        Task<List<EntityFiles>> List();
        Task<EntityFiles> GetById(long id);
        Task<SaveEntityFilesDTO> Save(SaveEntityFilesDTO model);
        Task<bool> Delete(long id);
    }
    public class EntityFilesService : BaseService, IEntityFilesService
    {
        private readonly IEntityFilesRepository _EntityFilesRepository;
        public EntityFilesService
        (
            IEntityFilesRepository EntityFilesRepository,
            JwtService jwtHelper
        ) : base(jwtHelper)
        {
            _EntityFilesRepository = EntityFilesRepository;
        }

        #region Getters

        public async Task<List<EntityFiles>> List()
        {
            return (await _EntityFilesRepository.ExecuteQueryAsync()).ToList();
        }

        public async Task<EntityFiles> GetById(long id)
        {
            return (await _EntityFilesRepository.ExecuteQueryAsync(x => x.Id == id)).FirstOrDefault() ?? new EntityFiles();
        }
        #endregion

        #region DB Access

        public async Task<SaveEntityFilesDTO> Save(SaveEntityFilesDTO model)
        {
            if (!Validate(model))
                throw new Exception("Ocurrió un error al intentar guardar el EntityFiles");

            EntityFiles u;

            if (model.Id == 0)
                u = await Insert(model);
            else
                u = await Update(model);
            await _EntityFilesRepository.SaveChanges();
            model.Id = (u?.Id ?? 0);

            return model;
        }
        private async Task<EntityFiles> Update(SaveEntityFilesDTO model)
        {
            return await _EntityFilesRepository.Update(new EntityFilesMapper().MapToEntityFiles(model));
        }
        private async Task<EntityFiles> Insert(SaveEntityFilesDTO model)
        {
            return await _EntityFilesRepository.Add(new EntityFilesMapper().MapToEntityFiles(model));
        }
        public async Task<bool> Delete(long id)
        {
            var u = await GetById(id);
            return await _EntityFilesRepository.SoftDelete(u);
        }
        private bool Validate(SaveEntityFilesDTO model)
        {
            return true;
        }
        #endregion
    }
}
