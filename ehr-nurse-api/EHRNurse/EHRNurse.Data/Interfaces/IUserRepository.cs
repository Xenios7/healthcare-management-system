using EHRNurse.Data.Models;

namespace EHRNurse.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);


        Task<User?> GetSingleAsync(CancellationToken ct = default);
    }
}
