using Dapper;
using FLP.DashboardEagle.Domain.Entity;
using FLP.DashboardEagle.Infraestructure.Interface;
using FLP.DashboardEagle.Transversal.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace FLP.DashboardEagle.Infraestructure.Repository
{
    public class EagleRepository : IEagleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;

        public EagleRepository(IConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory;
            _configuration = configuration;
        }
        
        #region Métodos síncronos
        public IEnumerable<EagleResponse> GetAll(DateTime date)
        {
            using(var connection = _connectionFactory.GetConnection)
            {
         
                    var query = _configuration.GetSection("Queries:sqlQueryGetAllEAGLE").Value!.ToString(); ;
                    query = query.Replace("@fecha", date.ToString("yyyy-MM-dd"));
                    var result = connection.Query<EagleResponse>(query);
                    return result;
                
            }
        }

        public IEnumerable<EagleResponse> GetDataByDay(DateTime startDate, DateTime endDate)
        {
            using (var connection = _connectionFactory.GetConnection) {
                var query = _configuration.GetSection("Queries:sqlQueryGetAllByDayEAGLE").Value!.ToString();
                query = query.Replace("@fecha", startDate.ToString("yyyy-MM-dd"));
                query = query.Replace("@siguienteDia", endDate.ToString("yyyy-MM-dd"));
                var result = connection.Query<EagleResponse>(query);
                return result;
            }
        }
        #endregion

        #region Métodos asíncronos
        public async Task<IEnumerable<EagleResponse>> GetAllAsync(DateTime date)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _configuration.GetSection("Queries:sqlQueryGetAllEAGLE").Value.ToString(); ;
                query = query.Replace("@fecha", date.ToString("yyyy-MM-dd"));
                var result = await connection.QueryAsync<EagleResponse>(query, commandType: CommandType.Text);
                return result;
            }
        }

        public async Task<IEnumerable<EagleResponse>> GetDataByDayAsync(DateTime startDate, DateTime endDate)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _configuration.GetSection("Queries:sqlQueryGetAllByDayEAGLE").Value.ToString(); ;
                query = query.Replace("@fecha", startDate.ToString("yyyy-MM-dd"));
                query = query.Replace("@siguienteDia", endDate.ToString("yyyy-MM-dd"));
                var result = await connection.QueryAsync<EagleResponse>(query, commandType: CommandType.Text);
                return result;
            }
        }
        #endregion
    }
}
