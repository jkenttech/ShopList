using API.Abstracts;
using Microsoft.AspNetCore.Identity;
namespace API.Models;

public class Login : UserAbstract
{
    private readonly PasswordHasher<UserAbstract> _hasher = new();
    required public string PasswordHash { get; set; }

    public PasswordVerificationResult VerifyPassword(string password)
    {
        return _hasher.VerifyHashedPassword(this, PasswordHash, password);
    }
}
