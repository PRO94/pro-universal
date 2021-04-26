namespace Pro.Universal.Data.DbContext
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Pro.Universal.Domain.Entities;

    public class ProUniversalContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ProUniversalContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}