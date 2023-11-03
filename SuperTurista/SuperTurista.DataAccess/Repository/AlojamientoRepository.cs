using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Repository
{
    public interface IAlojamientoRepository : IRepositoryBase<Alojamiento>
    {
        Task<Alojamiento> Add(Alojamiento entity);
        Task<Alojamiento> Update(Alojamiento entity);
        Task<bool> SoftDelete(Alojamiento entity);
    }
    public class AlojamientoRepository : RepositoryBase<Alojamiento>, IAlojamientoRepository
    {
        public AlojamientoRepository(
            DbContext context,
            Core.Helpers.JwtHelper jwtHelper
        ) : base(context, jwtHelper){}

        public async Task<Alojamiento> Add(Alojamiento entity)
        {
            await SoftAdd(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Alojamiento> Update(Alojamiento entity)
        {
            await SoftUpdate(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task SoftAdd(Alojamiento entity)
        {
            entity.Activo = true;
            AddBase(entity);
        }

        public async Task SoftUpdate(Alojamiento entity)
        {
            UpdateBase(entity);
        }
        public async Task<bool> SoftDelete(Alojamiento entity)
        {
            RemoveBase(entity);
            return true;
        }
    }
}
