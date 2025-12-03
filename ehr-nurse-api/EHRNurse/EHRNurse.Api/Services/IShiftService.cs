using EHRNurse.Api.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHRNurse.Api.Services
{
    public interface IShiftService
    {
       
        Task<ShiftResponseDto> ClockInAsync(string username);

        
        Task<ShiftResponseDto> ClockOutAsync(string username);

        
        Task<ShiftStatusDto> GetStatusAsync(string username);

        
        Task<IEnumerable<ShiftResponseDto>> GetHistoryAsync(string username, int pageNumber, int pageSize);
    }
}