using Microsoft.AspNetCore.Mvc;
using EHRNurse.Api.Dto;
using EHRNurse.Api.Services;

namespace EHRNurse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpPost("clock-in")]
        public async Task<IActionResult> ClockIn([FromBody] ShiftRequestDto request)
        {
            if (request.UserId <= 0)
                return BadRequest(new { message = "Invalid UserId." });

            var result = await _shiftService.ClockInAsync(request.UserId);

            if (result == null)
                return BadRequest(new { message = $"User {request.UserId} is already clocked in!" });

            return Ok(result);
        }

        [HttpPost("clock-out")]
        public async Task<IActionResult> ClockOut([FromBody] ShiftRequestDto request)
        {
            var result = await _shiftService.ClockOutAsync(request.UserId);

            if (result == null)
                return BadRequest(new { message = "User is not currently clocked in." });

            return Ok(result);
        }

        [HttpGet("status/{userId}")]
        public async Task<IActionResult> GetStatus(int userId)
        {
            var result = await _shiftService.GetStatusAsync(userId);
            return Ok(result);
        }
    }
}