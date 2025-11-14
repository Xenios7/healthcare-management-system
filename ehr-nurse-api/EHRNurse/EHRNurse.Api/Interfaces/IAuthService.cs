using EHRNurse.Api.Dto;

namespace EHRNurse.Api.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default);
    }
}
