using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Configurations
{
    public class EntityFilesConfiguration : IEntityTypeConfiguration<EntityFiles>
    {
        public void Configure(EntityTypeBuilder<EntityFiles> builder)
        {
            builder.ToTable("EntityFiles");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);
            
            builder.Property(f => f.FileExtension).HasMaxLength(10);
            builder.Property(f => f.FileName).HasMaxLength(300);

            builder.Property(f => f.CreationUser).HasMaxLength(100);
            builder.Property(f => f.ModifiedUser).HasMaxLength(100);

            builder.Property(f => f.CreationDate).IsRequired();
            builder.Property(f => f.LastModified).IsRequired();
        }
    }
}
