using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Activo).IsRequired();
            builder.Property(f => f.Login).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Email).HasMaxLength(255).IsRequired();

            builder.Property(f => f.Nombre).HasMaxLength(150);
            builder.Property(f => f.Apellido).HasMaxLength(150);

            builder.Property(f => f.CreationUser).HasMaxLength(100);
            builder.Property(f => f.ModifiedUser).HasMaxLength(100);

            builder.Property(f => f.CreationDate).IsRequired();
            builder.Property(f => f.LastModified).IsRequired();

            builder.HasIndex(f => f.Login);
        }
    }
}
