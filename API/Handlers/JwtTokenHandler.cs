using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using API.Models;

namespace API.Handlers;

internal sealed class JwtTokenHandler(IConfiguration config)
{
    public string GenerateToken(Login login)
    {
        SymmetricSecurityKey securtityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Secret"]!));
        SigningCredentials credentials = new SigningCredentials(securtityKey, SecurityAlgorithms.HmacSha256);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
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

        JsonWebTokenHandler handler = new JsonWebTokenHandler();

        return handler.CreateToken(tokenDescriptor);
    }
}
