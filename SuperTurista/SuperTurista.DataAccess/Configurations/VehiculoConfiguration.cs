using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Configurations
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("Vehiculo");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Activo).IsRequired();
            
            builder.Property(f => f.Titulo).HasMaxLength(150);
            builder.Property(f => f.Marca).HasMaxLength(150);
            builder.Property(f => f.Modelo).HasMaxLength(150);
            builder.Property(f => f.Detalle).HasMaxLength(150);

            builder.Property(f => f.CreationUser).HasMaxLength(100);
            builder.Property(f => f.ModifiedUser).HasMaxLength(100);

            builder.Property(f => f.CreationDate).IsRequired();
            builder.Property(f => f.LastModified).IsRequired();
        }
    }
}
