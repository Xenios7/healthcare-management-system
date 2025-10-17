using System;

namespace EHRNurse.Domain.Dto.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; } = default!;
        public DateTime? ExpiresAt { get; set; }   // optional, set if you want
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
