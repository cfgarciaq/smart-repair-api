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
    }
}
