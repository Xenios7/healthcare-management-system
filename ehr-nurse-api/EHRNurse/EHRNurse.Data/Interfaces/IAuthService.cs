using System.Threading;
using System.Threading.Tasks;
using EHRNurse.Domain.Dto.Auth;  

namespace EHRNurse.Data.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default);
    }
}
