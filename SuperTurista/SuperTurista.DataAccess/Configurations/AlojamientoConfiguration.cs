using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Configurations
{
    public class AlojamientoConfiguration : IEntityTypeConfiguration<Alojamiento>
    {
        public void Configure(EntityTypeBuilder<Alojamiento> builder)
        {
            builder.ToTable("Alojamiento");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Activo).IsRequired();
            
            builder.Property(f => f.Titulo).HasMaxLength(150);
            builder.Property(f => f.Ubicacion).HasMaxLength(150);
            builder.Property(f => f.Detalle).HasMaxLength(150);

            builder.Property(f => f.CreationUser).HasMaxLength(100);
            builder.Property(f => f.ModifiedUser).HasMaxLength(100);

            builder.Property(f => f.CreationDate).IsRequired();
            builder.Property(f => f.LastModified).IsRequired();
        }
    }
}
