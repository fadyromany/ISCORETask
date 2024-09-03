using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;


namespace ISCORETask.Core.Context
{
    public class ISCOREContext
    {
        private SettingSection connectionStringOptions;
        private readonly string _connectionString = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="EAContext"/> class.
        /// </summary>
        /// <param name="optionsMonitor">The options monitor.</param>
        public ISCOREContext(IOptions<SettingSection> optionsMonitor)
        {
            connectionStringOptions = optionsMonitor.Value;
            var dbPassword = Environment.GetEnvironmentVariable("EA_DB_PASSWORD");

            if (!string.IsNullOrEmpty(dbPassword))
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder(connectionStringOptions.SqlConnection)
                {
                    Password = dbPassword
                };

                _connectionString = connectionStringBuilder.ConnectionString;
            }
            else
            {
                _connectionString = connectionStringOptions.SqlConnection ?? "";
            }
        }
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns>An IDbConnection.</returns>
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
