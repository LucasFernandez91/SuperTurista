using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Repository
{
    public interface ISystemParametersRepository : IRepositoryBase<SystemParameters>
    { 
    }
    public class SystemParametersRepository : RepositoryBase<SystemParameters>, ISystemParametersRepository
    {
        public SystemParametersRepository(
            DbContext context,
            Core.Helpers.JwtHelper jwtHelper
        ) : base(context, jwtHelper){}

        public async Task Add(SystemParameters entity)
        {
            await SoftAdd(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(SystemParameters entity)
        {
            await SoftUpdate(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SoftAdd(SystemParameters entity)
        {
            AddBase(entity);
        }

        public async Task SoftUpdate(SystemParameters entity)
        {
            UpdateBase(entity);
        }
        public async Task SoftRemove(SystemParameters entity)
        {
            RemoveBase(entity);
        }
    }
}
