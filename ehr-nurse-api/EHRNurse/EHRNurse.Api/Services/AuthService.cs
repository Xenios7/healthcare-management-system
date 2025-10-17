using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using EHRNurse.Domain.Dto.Auth;
// using EHRNurse.Domain.Interfaces;
using EHRNurse.Data.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EHRNurse.Api.Services;

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
        var user = await _users.GetByEmailAsync(request.Email, ct);
        if (user == null || user.IsActive == false) return null;

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            return null;

        if (string.IsNullOrWhiteSpace(user.Roles))
            return null; // no null is accepted at user.role

        var role = user.Roles.Trim();
        var valid = role.Equals("Nurse", StringComparison.OrdinalIgnoreCase)
                 || role.Equals("Doctor", StringComparison.OrdinalIgnoreCase);
        if (!valid) return null;

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
        new Claim(ClaimTypes.Role, role)
    };

        var handler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

        var token = handler.CreateJwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            subject: new ClaimsIdentity(claims),
            expires: DateTime.UtcNow.AddMinutes(_jwt.ExpiresMinutes),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new LoginResponse
        {
            Token = handler.WriteToken(token),
            Email = user.Email,
            FirstName = user.FirstName ?? "",
            LastName = user.LastName ?? "",
            Role = role
        };
    }
}