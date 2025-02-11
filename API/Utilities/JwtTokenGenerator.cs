using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using API.Models;

namespace API.Utilities;

internal sealed class JwtTokenGenerator(IConfiguration config)
{
    public string GenerateToken(Login login)
    {
        SymmetricSecurityKey securtityKey = new(Encoding.UTF8.GetBytes(config["Jwt:Secret"]!));
        SigningCredentials credentials = new(securtityKey, SecurityAlgorithms.HmacSha256);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Email, login.Email)
            ]),
            Expires = DateTime.UtcNow.AddMinutes(config.GetValue<int>("Jwt:TTLInMinutes")),
            SigningCredentials = credentials,
            Issuer = config["Jwt:Issuer"],
            Audience = config["Jwt:Audience"]
        };

        JsonWebTokenHandler handler = new();

        return handler.CreateToken(tokenDescriptor);
    }
}
