namespace API.Models;

internal class Login
{
    public int Id { get; init; }

    public string Email { get; set; } = "N/A";

    public string PasswordHash { get; set; } = "N/A";
}
