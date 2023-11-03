using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Repository
{
    public interface IEntityFilesRepository : IRepositoryBase<EntityFiles>
    {
        Task<EntityFiles> Add(EntityFiles entity);
        Task<EntityFiles> Update(EntityFiles entity);
        Task<bool> SoftDelete(EntityFiles entity);
    }
    public class EntityFilesRepository : RepositoryBase<EntityFiles>, IEntityFilesRepository
    {
        public EntityFilesRepository(
            DbContext context,
            Core.Helpers.JwtHelper jwtHelper
        ) : base(context, jwtHelper){}

        public async Task<EntityFiles> Add(EntityFiles entity)
        {
            await SoftAdd(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EntityFiles> Update(EntityFiles entity)
        {
            await SoftUpdate(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task SoftAdd(EntityFiles entity)
        {
            AddBase(entity);
        }

        public async Task SoftUpdate(EntityFiles entity)
        {
            UpdateBase(entity);
        }
        public async Task<bool> SoftDelete(EntityFiles entity)
        {
            RemoveBase(entity);
            return true;
        }
    }
}
