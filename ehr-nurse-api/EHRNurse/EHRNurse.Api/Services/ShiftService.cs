using EHRNurse.Api.Dto;
using EHRNurse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EHRNurse.Api.Services
{
    public class ShiftService : IShiftService
    {
        private readonly AppDbContext _context;

        public ShiftService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ShiftResponseDto?> ClockInAsync(int userId)
        {
            if (userId <= 0)
                return null;

            var activeShift = await _context.Shifts
                .FirstOrDefaultAsync(s => s.UserId == userId && s.ClockOutTime == null);

            if (activeShift != null)
                return null;

            var newShift = new Shift
            {
                UserId = userId,
                ClockInTime = DateTime.UtcNow
            };

            _context.Shifts.Add(newShift);
            await _context.SaveChangesAsync();

            return new ShiftResponseDto
            {
                ShiftId = newShift.Id,
                UserId = newShift.UserId,
                Timestamp = newShift.ClockInTime,
                Status = "Clocked In"
            };
        }

        public async Task<ShiftResponseDto?> ClockOutAsync(int userId)
        {
            var activeShift = await _context.Shifts
                .FirstOrDefaultAsync(s => s.UserId == userId && s.ClockOutTime == null);

            if (activeShift == null)
                return null;

            activeShift.ClockOutTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return new ShiftResponseDto
            {
                ShiftId = activeShift.Id,
                UserId = activeShift.UserId,
                Timestamp = activeShift.ClockOutTime.Value,
                Status = "Clocked Out"
            };
        }

        public async Task<object> GetStatusAsync(int userId)
        {
            var activeShift = await _context.Shifts
                .FirstOrDefaultAsync(s => s.UserId == userId && s.ClockOutTime == null);

            if (activeShift != null)
            {
                return new
                {
                    status = "On Shift",
                    shiftId = activeShift.Id,
                    startTime = activeShift.ClockInTime
                };
            }

            return new { status = "Off Shift" };
        }
    }
}