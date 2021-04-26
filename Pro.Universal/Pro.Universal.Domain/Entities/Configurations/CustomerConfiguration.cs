using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pro.Universal.Domain.Entities.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Address).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(50);
            builder.Property(t => t.DateOfBirth).IsRequired();
            builder.Property(t => t.RoleId).IsRequired();


            builder.HasOne<Role>()
                .WithMany(x => x.Customers)
                .HasForeignKey(s => s.RoleId);
        }
    }
}