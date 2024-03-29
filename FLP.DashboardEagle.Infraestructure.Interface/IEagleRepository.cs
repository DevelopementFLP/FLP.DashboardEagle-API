using FLP.DashboardEagle.Domain.Entity;

namespace FLP.DashboardEagle.Infraestructure.Interface
{
    public interface IEagleRepository
    {
        #region Método síncronos
        IEnumerable<EagleResponse> GetAll(DateTime date);
        IEnumerable<EagleResponse> GetDataByDay(DateTime startDate, DateTime endDate);
        #endregion

        #region Métodos asíncronos
        Task<IEnumerable<EagleResponse>> GetAllAsync(DateTime date);
        Task<IEnumerable<EagleResponse>> GetDataByDayAsync(DateTime startDate, DateTime endDate);
        #endregion
    }
}
