using EHRNurse.Api.Dto;
using EHRNurse.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EHRNurse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            return BadRequest(new { message = "Email and password are required" });

        var res = await _auth.LoginAsync(request, ct);
        if (res == null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(res);
    }
}
