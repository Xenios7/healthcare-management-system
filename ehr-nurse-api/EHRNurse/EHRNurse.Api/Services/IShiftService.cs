using EHRNurse.Api.Dto;

namespace EHRNurse.Api.Services
{
    public interface IShiftService
    {
        Task<ShiftResponseDto?> ClockInAsync(int userId);
        Task<ShiftResponseDto?> ClockOutAsync(int userId);
        Task<object> GetStatusAsync(int userId);
    }
}