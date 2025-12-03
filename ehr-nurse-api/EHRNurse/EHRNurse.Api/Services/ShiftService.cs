using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EHRNurse.Api.Dto;
using EHRNurse.Data;
using EHRNurse.Data.Models;

namespace EHRNurse.Api.Services
{
    public class ShiftService : IShiftService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ShiftService> _logger;

        public ShiftService(AppDbContext context, ILogger<ShiftService> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public async Task<ShiftResponseDto> ClockInAsync(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    _logger.LogWarning("Clock in attempt with empty username");
                    return null;
                }

                // Find user by username
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    _logger.LogWarning($"Clock in attempt with non-existent username: {username}");
                    return null;
                }

                // Check if user is already clocked in
                var activeShift = await _context.Shifts
                    .Where(s => s.UserId == user.Id && s.ClockOutTime == null)
                    .FirstOrDefaultAsync();

                if (activeShift != null)
                {
                    _logger.LogWarning($"User {username} attempted to clock in while already clocked in");
                    return null; // User is already clocked in
                }

                // Create new shift record
                var shift = new Shift
                {
                    UserId = user.Id,
                    ClockInTime = DateTime.UtcNow
                };

                _context.Shifts.Add(shift);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"User {username} clocked in at {shift.ClockInTime}");

                return MapToDto(shift, user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during clock in for user {username}: {ex.Message}");
                throw;
            }
        }

        
        public async Task<ShiftResponseDto> ClockOutAsync(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    _logger.LogWarning("Clock out attempt with empty username");
                    return null;
                }

                // Find user by username
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    _logger.LogWarning($"Clock out attempt with non-existent username: {username}");
                    return null;
                }

                // Find active shift
                var activeShift = await _context.Shifts
                    .Where(s => s.UserId == user.Id && s.ClockOutTime == null)
                    .FirstOrDefaultAsync();

                if (activeShift == null)
                {
                    _logger.LogWarning($"User {username} attempted to clock out without an active shift");
                    return null; // No active shift found
                }

                // Update shift with clock out time
                activeShift.ClockOutTime = DateTime.UtcNow;
                _context.Shifts.Update(activeShift);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"User {username} clocked out at {activeShift.ClockOutTime}");

                return MapToDto(activeShift, user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during clock out for user {username}: {ex.Message}");
                throw;
            }
        }

        
        public async Task<ShiftStatusDto> GetStatusAsync(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    _logger.LogWarning("Get status attempt with empty username");
                    return null;
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    _logger.LogWarning($"Get status attempt with non-existent username: {username}");
                    return null;
                }

                var activeShift = await _context.Shifts
                    .Where(s => s.UserId == user.Id && s.ClockOutTime == null)
                    .FirstOrDefaultAsync();

                var status = new ShiftStatusDto
                {
                    UserId = user.Id,
                    UserName = user.Username,
                    UserFullName = $"{user.FirstName} {user.LastName}",
                    IsCurrentlyClocked = activeShift != null,
                    CurrentClockInTime = activeShift?.ClockInTime,
                    Status = activeShift != null ? "Σε βάρδια" : "Εκτός βάρδιας"
                };

                _logger.LogInformation($"Retrieved status for user {username}: {status.Status}");
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting shift status for user {username}: {ex.Message}");
                throw;
            }
        }

        
        public async Task<IEnumerable<ShiftResponseDto>> GetHistoryAsync(string username, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    _logger.LogWarning("Get history attempt with empty username");
                    return null;
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    _logger.LogWarning($"Get history attempt with non-existent username: {username}");
                    return null;
                }

                var shifts = await _context.Shifts
                    .Where(s => s.UserId == user.Id)
                    .OrderByDescending(s => s.ClockInTime)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var historyDtos = shifts.Select(s => MapToDto(s, user)).ToList();

                _logger.LogInformation($"Retrieved {historyDtos.Count} shift records for user {username}");
                return historyDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting shift history for user {username}: {ex.Message}");
                throw;
            }
        }

        
        private ShiftResponseDto MapToDto(Shift shift, User user)
        {
            return new ShiftResponseDto
            {
                Id = shift.Id,
                UserId = shift.UserId,
                ClockInTime = shift.ClockInTime,
                ClockOutTime = shift.ClockOutTime,
                IsActive = shift.IsActive,
                UserName = user.Username,
                UserFullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}