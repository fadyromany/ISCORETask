using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ISCORETask.DAL.Repository.Abstractions;
using ISCORETask.Objects;

namespace ISCORETask.DAL
{
    public class ISCORETaskDbContext : IdentityDbContext<IdentityUser>
    {
        public ISCORETaskDbContext(DbContextOptions<ISCORETaskDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookVM> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookVM>()
                .ToTable("Books", "BookManagement");
        }

    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ISCORETaskDbContext>
    {
        private readonly IConfigurationRepository configuration;

      
        public ISCORETaskDbContext CreateDbContext(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ISCORETaskDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string 'DefaultConnection' is not found in the appsettings.json.");
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new ISCORETaskDbContext(optionsBuilder.Options);
        }
    }
}
