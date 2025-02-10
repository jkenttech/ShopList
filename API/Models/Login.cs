namespace API.Models;

public class Login
{
    public int Id { get; init; }

    required public string Email { get; set; }

    required public string PasswordHash { get; set; }
}
