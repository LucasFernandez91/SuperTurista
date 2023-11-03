using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Configurations
{
    public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.ToTable("UsuarioRol");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Activo).IsRequired();
            builder.Property(f => f.UsuarioId).IsRequired();
            builder.Property(f => f.RolId).IsRequired();

            builder.Property(f => f.CreationUser).HasMaxLength(100);
            builder.Property(f => f.ModifiedUser).HasMaxLength(100);

            builder.Property(f => f.CreationDate).IsRequired();
            builder.Property(f => f.LastModified).IsRequired();
        }
    }
}
