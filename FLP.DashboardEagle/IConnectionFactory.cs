using System.Data;

namespace FLP.DashboardEagle.Transversal.Common
{
    public interface IConnectionFactory
    {
        public IDbConnection? GetConnection(string connectionString);
    }
}
