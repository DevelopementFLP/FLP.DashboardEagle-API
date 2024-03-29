using FLP.DashboardEagle.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLP.DashboardEagle.Infraestructure.Data
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection? GetConnection
        {
            get
            {
                var connection = new SqlConnection(_configuration.GetConnectionString("HPConnectionString"));
                connection.Open();
                return connection;
            }
        }
    }
}
