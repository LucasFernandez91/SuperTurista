using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Repository
{
    public interface IVehiculoRepository : IRepositoryBase<Vehiculo>
    {
        Task<Vehiculo> Add(Vehiculo entity);
        Task<Vehiculo> Update(Vehiculo entity);
        Task<bool> SoftDelete(Vehiculo entity);
    }
    public class VehiculoRepository : RepositoryBase<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(
            DbContext context,
            Core.Helpers.JwtHelper jwtHelper
        ) : base(context, jwtHelper){}

        public async Task<Vehiculo> Add(Vehiculo entity)
        {
            await SoftAdd(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Vehiculo> Update(Vehiculo entity)
        {
            await SoftUpdate(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task SoftAdd(Vehiculo entity)
        {
            entity.Activo = true;
            AddBase(entity);
        }

        public async Task SoftUpdate(Vehiculo entity)
        {
            UpdateBase(entity);
        }
        public async Task<bool> SoftDelete(Vehiculo entity)
        {
            RemoveBase(entity);
            return true;
        }
    }
}
