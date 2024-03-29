using FLP.DashboardEagle.Application.Dto;
using FLP.DashboardEagle.Transversal.Common;

namespace FLP.DashboardEagle.Application.Interface
{
    public interface IEagleResponseApplication
    {
        #region Métodos síncronos
        Response<IEnumerable<EagleResponseDto>> GetAll(DateTime date);
        Response<IEnumerable<EagleResponseDto>> GetDataByDay(DateTime startDate, DateTime endDate);
        #endregion

        #region Métodos asíncronos
        Task<Response<IEnumerable<EagleResponseDto>>> GetAllAsync(DateTime date);
        Task<Response<IEnumerable<EagleResponseDto>>> GetDataByDayAsync(DateTime startDate, DateTime endDate);
        #endregion
    }
}
