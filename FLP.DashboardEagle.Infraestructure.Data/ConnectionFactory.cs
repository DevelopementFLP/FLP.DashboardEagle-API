using FLP.DashboardEagle.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;

namespace FLP.DashboardEagle.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection? GetConnection
        {
            get
            {
                var connection = new NpgsqlConnection(_configuration.GetConnectionString("EagleConnectionString"));
                
                try
                {
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
}
