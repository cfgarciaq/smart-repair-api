using Microsoft.EntityFrameworkCore;
using SmartRepairApi.Models;

namespace SmartRepairApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<RepairHistory> RepairHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure all DateTime properties to use 'timestamp with time zone'
            // This is the recommended way for Npgsql 6.0+
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?));

                foreach (var property in properties)
                {
                    property.SetColumnType("timestamp with time zone");
                }
            }
        }
    }
}
