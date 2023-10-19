using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Models;

namespace SuperTurista.DataAccess.Configurations
{
    public class SystemParametersConfiguration : IEntityTypeConfiguration<SystemParameters>
    {
        public void Configure(EntityTypeBuilder<SystemParameters> builder)
        {
            builder.ToTable("SystemParameters");

            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Value).IsRequired();
            builder.Property(f => f.CanAccessAnon).HasDefaultValue(true);
            builder.Property(f => f.Code).HasMaxLength(255).IsRequired();
            builder.Property(f => f.Comment).HasMaxLength(150);

            builder.Property(f => f.CreationUser).HasMaxLength(100);
            builder.Property(f => f.ModifiedUser).HasMaxLength(100);

            builder.Property(f => f.CreationDate).IsRequired();
            builder.Property(f => f.LastModified).IsRequired();
        }
    }
}
