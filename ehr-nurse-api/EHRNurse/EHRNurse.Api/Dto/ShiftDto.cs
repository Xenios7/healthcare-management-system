using System;
using System.ComponentModel.DataAnnotations;

namespace EHRNurse.Api.Dto
{
    /// <summary>
    /// DTO for Clock In/Clock Out requests - uses username for easier input
    /// </summary>
    public class ShiftRequestDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Username must be between 1 and 255 characters")]
        public string Username { get; set; }
    }

    /// <summary>
    /// DTO for Shift responseT
    /// </summary>
    public class ShiftResponseDto
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime ClockInTime { get; set; }

        public DateTime? ClockOutTime { get; set; }

        public bool IsActive { get; set; }

        public string? UserName { get; set; }

        public string? UserFullName { get; set; }

        public TimeSpan? ShiftDuration
        {
            get
            {
                if (ClockOutTime.HasValue)
                {
                    return ClockOutTime.Value - ClockInTime;
                }
                return null;
            }
        }
    }

    /// <summary>
    /// DTO for current shift status
    /// </summary>
    public class ShiftStatusDto
    {
        public Guid UserId { get; set; }

        public bool IsCurrentlyClocked { get; set; }

        public DateTime? CurrentClockInTime { get; set; }

        public string? Status { get; set; } // "Σε βάρδια" (In shift) or "Εκτός βάρδιας" (Off shift)

        public string? UserName { get; set; }

        public string? UserFullName { get; set; }
    }
}