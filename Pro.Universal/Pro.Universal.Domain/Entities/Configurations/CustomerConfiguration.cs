using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pro.Universal.Domain.Entities.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.FirstName).IsRequired();
            builder.Property(t => t.LastName).IsRequired();
            builder.Property(t => t.Address).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.DateOfBirth).IsRequired();
            builder.Property(t => t.RoleId).IsRequired();


            builder.HasOne<Role>()
                .WithMany(x => x.Customers)
                .HasForeignKey(s => s.RoleId);
        }
    }
}