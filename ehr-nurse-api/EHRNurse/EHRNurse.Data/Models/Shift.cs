using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHRNurse.Data.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }

        // Links the shift to the specific Nurse/Doctor
        [Required]
        public string UserId { get; set; }

        // The exact time they started
        public DateTime ClockInTime { get; set; }

        // The time they finished (Nullable, because it's empty while they are working)
        public DateTime? ClockOutTime { get; set; }

        // Helper to quickly check if they are currently working
        [NotMapped] 
        public bool IsActive => ClockOutTime == null;
    }
}