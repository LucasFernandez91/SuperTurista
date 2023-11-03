using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Helpers;
using SuperTurista.DataAccess.Configurations;

namespace SuperTurista.DataAccess
{
    public class SuperTuristaDbContext : DbContext
    {
        public new DbSet<T> Set<T>() where T : class { return base.Set<T>(); }
        private readonly JwtHelper _jwtHelper;
        public SuperTuristaDbContext(
            DbContextOptions<SuperTuristaDbContext> options,
            JwtHelper jwtHelper
        ) : base(options)
        {
            _jwtHelper = jwtHelper;
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new SystemParametersConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new VehiculoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRolConfiguration());
            modelBuilder.ApplyConfiguration(new AlojamientoConfiguration());
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
