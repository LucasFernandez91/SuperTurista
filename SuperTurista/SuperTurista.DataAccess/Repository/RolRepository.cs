using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Repository
{
    public interface IRolRepository : IRepositoryBase<Rol>
    {
        Task<Rol> Add(Rol entity);
        Task<Rol> Update(Rol entity);
        Task<bool> SoftDelete(Rol entity);
    }
    public class RolRepository : RepositoryBase<Rol>, IRolRepository
    {
        public RolRepository(
            DbContext context,
            Core.Helpers.JwtHelper jwtHelper
        ) : base(context, jwtHelper){}

        public async Task<Rol> Add(Rol entity)
        {
            await SoftAdd(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Rol> Update(Rol entity)
        {
            await SoftUpdate(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task SoftAdd(Rol entity)
        {
            entity.Activo = true;
            AddBase(entity);
        }

        public async Task SoftUpdate(Rol entity)
        {
            UpdateBase(entity);
        }
        public async Task<bool> SoftDelete(Rol entity)
        {
            RemoveBase(entity);
            return true;
        }
    }
}
