using InventoryManagementSystemDomain.Entity;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemInfrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Login> LoginUsers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
