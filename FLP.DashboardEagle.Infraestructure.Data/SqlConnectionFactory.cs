using FLP.DashboardEagle.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FLP.DashboardEagle.Infraestructure.Data
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection? GetConnection(string connectionString)
        {

            var connection = new SqlConnection(_configuration.GetConnectionString(connectionString));
            connection.Open();
            return connection;

        }
    }
}
