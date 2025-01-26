using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Microsoft.Extensions.Configuration;

namespace Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PartidaConfiguration());

            base.OnConfiguring(new DbContextOptionsBuilder());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: true)
                             .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Partida> Partidas { get; set; }
    }
}
