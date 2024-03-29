using FLP.DashboardEagle.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLP.DashboardEagle.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EagleResponseController : ControllerBase
    {
        private readonly IEagleResponseApplication _eagleResponseApplication;

        public EagleResponseController(IEagleResponseApplication eagleResponseApplication) => _eagleResponseApplication = eagleResponseApplication;

        #region Métodos síncronos
        [HttpGet("GetAll")]
        public IActionResult GetAll(DateTime date)
        {
            var response = _eagleResponseApplication.GetAll(date);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("GetDataByDay")]
        public IActionResult GetDataByDay(DateTime startDate, DateTime endDate)
        {
            var response = _eagleResponseApplication.GetDataByDay(startDate, endDate);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion

        #region Métodos asíncronos
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync(DateTime date)
        {
            var response = await _eagleResponseApplication.GetAllAsync(date);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("GetDataByDayAsync")]
        public async Task<IActionResult> GetDataByDayAsync(DateTime startDate, DateTime endDate)
        {
            var response = await _eagleResponseApplication.GetDataByDayAsync(startDate, endDate);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion
    }
}
