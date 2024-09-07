using ISCORETask.DAL.Repository.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DAL.Repository.Implementations
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IConfiguration configuration;
        private string connectionString { get; set; }
        public ConfigurationRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        public string ConnectionString { get { return connectionString; } }
    }
}
