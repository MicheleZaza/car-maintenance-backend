using Microsoft.EntityFrameworkCore;
using CarMaintenanceApi.Models;

namespace CarMaintenanceApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Maintenance> Maintenances { get; set; }
    }
}