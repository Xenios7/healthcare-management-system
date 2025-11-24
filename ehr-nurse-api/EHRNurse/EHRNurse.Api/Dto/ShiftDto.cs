namespace EHRNurse.Api.Dto
{
    public class ShiftRequestDto
    {
        public int UserId { get; set; }
    }

    public class ShiftResponseDto
    {
        public int ShiftId { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}