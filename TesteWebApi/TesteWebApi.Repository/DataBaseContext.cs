using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteWebApi.Domain.Models;

namespace TesteWebApi.Repository
{
    public class DataBaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataBaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Parking> Parking { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}