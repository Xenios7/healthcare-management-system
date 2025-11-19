using Microsoft.AspNetCore.Mvc;
using EHRNurse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EHRNurse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShiftController(AppDbContext context)
        {
            _context = context;
        }

        // 1. CLOCK IN
        // POST: api/Shift/clock-in
        [HttpPost("clock-in")]
        public async Task<IActionResult> ClockIn([FromBody] string userId)
        {
            // Check if the user is already working (has a shift with NO end time)
            var activeShift = await _context.Shifts
                .FirstOrDefaultAsync(s => s.UserId == userId && s.ClockOutTime == null);

            if (activeShift != null)
            {
                return BadRequest(new { message = "User is already clocked in!" });
            }

            // ERROR WAS HERE: Ensure we use '='
            var newShift = new Shift
            {
                UserId = userId,
                ClockInTime = DateTime.UtcNow 
            };

            _context.Shifts.Add(newShift);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Clocked in successfully", startTime = newShift.ClockInTime });
        }

        // 2. CLOCK OUT
        // POST: api/Shift/clock-out
        [HttpPost("clock-out")]
        public async Task<IActionResult> ClockOut([FromBody] string userId)
        {
            var activeShift = await _context.Shifts
                .FirstOrDefaultAsync(s => s.UserId == userId && s.ClockOutTime == null);

            if (activeShift == null)
            {
                return BadRequest(new { message = "User is not currently clocked in." });
            }

            activeShift.ClockOutTime = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();

            return Ok(new { message = "Clocked out successfully", endTime = activeShift.ClockOutTime });
        }

        // 3. GET STATUS
        // GET: api/Shift/status/{userId}
        [HttpGet("status/{userId}")]
        public async Task<IActionResult> GetStatus(string userId)
        {
            var activeShift = await _context.Shifts
                .FirstOrDefaultAsync(s => s.UserId == userId && s.ClockOutTime == null);

            if (activeShift != null)
            {
                return Ok(new { status = "On Shift", startTime = activeShift.ClockInTime });
            }
            
            return Ok(new { status = "Off Shift" });
        }
    }
}