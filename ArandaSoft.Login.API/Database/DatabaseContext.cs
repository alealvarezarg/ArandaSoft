using ArandaSoft.Login.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArandaSoft.Login.API.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguration());
        }
    }
}
