using EHRNurse.Domain.Dto.Auth;
//using EHRNurse.Domain.Interfaces;
using EHRNurse.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EHRNurse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req, CancellationToken ct)
    {
        var res = await _auth.LoginAsync(req, ct);
        if (res == null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(res);
    }
}