using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using EHRNurse.Api.Dto;
using EHRNurse.Api.Interfaces;
using EHRNurse.Data.Interfaces;
using EHRNurse.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EHRNurse.Api.Services
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string Key { get; set; } = default!;
        public int ExpiresMinutes { get; set; } = 60;
    }

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly JwtOptions _jwt;

        public AuthService(IUserRepository users, IOptions<JwtOptions> jwtOptions)
        {
            _users = users;
            _jwt = jwtOptions.Value;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default)
        {
            // ---------------- ICONIC LOGIN ONLY ----------------
            const string iconicUserName = "adminehr";
            const string iconicPassword = "adminehr";

            var isIconic = request?.Email?.Equals(iconicUserName, StringComparison.OrdinalIgnoreCase) == true
                           && request.Password == iconicPassword;

            if (!isIconic)
                return null; // Only iconic login is allowed for now

            // Pull the single/first (active) user from DB
            var user = await _users.GetSingleAsync(ct);
            if (user == null || !user.IsActive)
                return null;

            // Map ICollection<Role> -> List<string> role names
            var roleNames = (user.Roles != null && user.Roles.Any())
                ? user.Roles
                    .Select(r => r?.Name)
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList()!
                : new List<string> { "User" };

            // Build claims (include all roles)
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, string.IsNullOrWhiteSpace(user.Email) ? iconicUserName : user.Email!),
                new Claim(ClaimTypes.Name, $"{user.FirstName ?? ""} {user.LastName ?? ""}".Trim())
            };

            foreach (var roleName in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

            // Create JWT
            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var token = handler.CreateJwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                subject: new ClaimsIdentity(claims),
                expires: DateTime.UtcNow.AddMinutes(_jwt.ExpiresMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Return response
            return new LoginResponse
            {
                Token = handler.WriteToken(token),
                ExpiresAt = token.ValidTo,
                Email = user.Email ?? iconicUserName,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Role = string.Join(",", roleNames)
            };
        }
    }
}
