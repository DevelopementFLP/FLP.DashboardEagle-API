using FLP.DashboardEagle.Domain.Entity;
using FLP.DashboardEagle.Domain.Interface;
using FLP.DashboardEagle.Infraestructure.Interface;

namespace FLP.DashboardEagle.Domain.Core
{
    public class EagleResponseDomain : IEagleResponseDomain
    {
        private readonly IEagleRepository _eagleRespository;

        public EagleResponseDomain(IEagleRepository eagleRespository) => _eagleRespository = eagleRespository;

        #region Métodos síncronos
        public IEnumerable<EagleResponse> GetAll(DateTime date) => _eagleRespository.GetAll(date);
        public IEnumerable<EagleResponse> GetDataByDay(DateTime startDate, DateTime endDate) => _eagleRespository.GetDataByDay(startDate, endDate);
        #endregion

        #region Métodos asíncronos
        public async Task<IEnumerable<EagleResponse>> GetAllAsync(DateTime date) => await _eagleRespository.GetAllAsync(date);
        public async Task<IEnumerable<EagleResponse>> GetDataByDayAsync(DateTime startDate, DateTime endDate) => await _eagleRespository.GetDataByDayAsync(startDate, endDate);
        #endregion
    }
}
