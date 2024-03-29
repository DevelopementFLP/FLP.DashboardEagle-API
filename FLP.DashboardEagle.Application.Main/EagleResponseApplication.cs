using AutoMapper;
using FLP.DashboardEagle.Application.Dto;
using FLP.DashboardEagle.Application.Interface;
using FLP.DashboardEagle.Domain.Interface;
using FLP.DashboardEagle.Transversal.Common;

namespace FLP.DashboardEagle.Application.Main
{
    public class EagleResponseApplication : IEagleResponseApplication
    {
        private readonly IEagleResponseDomain _eagleResponseDomain;
        private readonly IMapper _mapper;

        public EagleResponseApplication(IEagleResponseDomain eagleResponseDomain, IMapper mapper)
        {
            _eagleResponseDomain = eagleResponseDomain;
            _mapper = mapper;
        }

        #region Métodos síncronos
        public Response<IEnumerable<EagleResponseDto>> GetAll(DateTime date)
        {
            var response = new Response<IEnumerable<EagleResponseDto>>();
            try
            {
                var result = _eagleResponseDomain.GetAll(date);
                response.Data = _mapper.Map<IEnumerable<EagleResponseDto>>(result);
                if(response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<IEnumerable<EagleResponseDto>> GetDataByDay(DateTime startDate,  DateTime endDate)
        {
            var response = new Response<IEnumerable<EagleResponseDto>>();
            try
            {
                var result = _eagleResponseDomain.GetDataByDay(startDate, endDate);
                response.Data = _mapper.Map<IEnumerable<EagleResponseDto>>(result);
                if(response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        #endregion

        #region Métodos asíncronos
        public async Task<Response<IEnumerable<EagleResponseDto>>> GetAllAsync(DateTime date)
        {
            var response = new Response<IEnumerable<EagleResponseDto>>();
            try
            {
                var result = await _eagleResponseDomain.GetAllAsync(date);
                response.Data = _mapper.Map<IEnumerable<EagleResponseDto>>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<EagleResponseDto>>> GetDataByDayAsync(DateTime startDay, DateTime endDate)
        {
            var response = new Response<IEnumerable<EagleResponseDto>>();
            try
            {
                var result = await _eagleResponseDomain.GetDataByDayAsync(startDay, endDate);
                response.Data = _mapper.Map<IEnumerable<EagleResponseDto>>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        #endregion
    }
}
