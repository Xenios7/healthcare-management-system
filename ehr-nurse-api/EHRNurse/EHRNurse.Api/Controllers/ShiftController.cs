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
        private readonly ILogger<ShiftController> _logger;

        public ShiftController(IShiftService shiftService, ILogger<ShiftController> logger)
        {
            _shiftService = shiftService;
            _logger = logger;
        }

        
        [HttpPost("clock-in")]
        public async Task<IActionResult> ClockIn([FromBody] ShiftRequestDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username))
                return BadRequest(new { message = "Username is required and cannot be empty." });

            try
            {
                var result = await _shiftService.ClockInAsync(request.Username);

                if (result == null)
                    return BadRequest(new { message = $"Failed to clock in. User '{request.Username}' either doesn't exist or is already clocked in." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during clock in: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred during clock in.", error = ex.Message });
            }
        }

        
        [HttpPost("clock-out")]
        public async Task<IActionResult> ClockOut([FromBody] ShiftRequestDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username))
                return BadRequest(new { message = "Username is required and cannot be empty." });

            try
            {
                var result = await _shiftService.ClockOutAsync(request.Username);

                if (result == null)
                    return BadRequest(new { message = $"Failed to clock out. User '{request.Username}' either doesn't exist or has no active shift." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during clock out: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred during clock out.", error = ex.Message });
            }
        }

        
        [HttpGet("status/{username}")]
        public async Task<IActionResult> GetStatus(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest(new { message = "Username is required and cannot be empty." });

            try
            {
                var result = await _shiftService.GetStatusAsync(username);

                if (result == null)
                    return NotFound(new { message = $"No shift status found for user '{username}'." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving shift status: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while retrieving shift status.", error = ex.Message });
            }
        }

        
        [HttpGet("history/{username}")]
        public async Task<IActionResult> GetHistory(string username, int pageNumber = 1, int pageSize = 10)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest(new { message = "Username is required and cannot be empty." });

            if (pageNumber < 1)
                return BadRequest(new { message = "Page number must be greater than 0." });

            if (pageSize < 1 || pageSize > 100)
                return BadRequest(new { message = "Page size must be between 1 and 100." });

            try
            {
                var result = await _shiftService.GetHistoryAsync(username, pageNumber, pageSize);

                if (result == null || !result.Any())
                    return NotFound(new { message = $"No shift history found for user '{username}'." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving shift history: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while retrieving shift history.", error = ex.Message });
            }
        }
    }
}