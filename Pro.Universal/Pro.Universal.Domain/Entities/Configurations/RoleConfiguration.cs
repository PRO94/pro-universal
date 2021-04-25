using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pro.Universal.Domain.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();
        }
    }
}