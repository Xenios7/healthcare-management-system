using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EHRNurse.Data.Interfaces;
using EHRNurse.Data.Models;

namespace EHRNurse.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, ct);
        }
        
    }
}