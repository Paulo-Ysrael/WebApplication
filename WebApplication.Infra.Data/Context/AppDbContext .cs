using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebApplication.Domain.Entity;
using WebApplication.Infra.Data.EntitiesConfiguration;

namespace WebApplication.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public DbSet<Members> Members { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Association> Association { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MembersConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new AssociationConfiguration());
        }
    }
}
