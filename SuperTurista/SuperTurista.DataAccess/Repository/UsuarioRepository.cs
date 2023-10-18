using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTurista.DataAccess.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<bool> SoftDelete(Usuario entity);
    }
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(
            DbContext context,
            Core.Helpers.JwtHelper jwtHelper
        ) : base(context, jwtHelper){}

        public async Task Add(Usuario entity)
        {
            await SoftAdd(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Usuario entity)
        {
            await SoftUpdate(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SoftAdd(Usuario entity)
        {
            entity.Activo = true;
            AddBase(entity);
        }

        public async Task SoftUpdate(Usuario entity)
        {
            UpdateBase(entity);
        }
        public async Task<bool> SoftDelete(Usuario entity)
        {
            RemoveBase(entity);
            return true;
        }
    }
}
