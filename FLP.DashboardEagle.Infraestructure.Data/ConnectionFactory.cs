using FLP.DashboardEagle.Transversal.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace FLP.DashboardEagle.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection? GetConnection(string connectionString)
        {
            IDbConnection? connection = null;

            try
            {
                connection = new NpgsqlConnection(_configuration.GetConnectionString(connectionString));

                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connection = null;
            }
            return connection;
        }
    }
}
