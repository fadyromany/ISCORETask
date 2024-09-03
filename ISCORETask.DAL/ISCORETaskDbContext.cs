using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ISCORETask.DAL
{
    public class ISCORETaskDbContext : IdentityDbContext<IdentityUser>
    {
        public ISCORETaskDbContext(DbContextOptions<ISCORETaskDbContext> options)
            : base(options)
        {
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
