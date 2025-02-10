namespace API.Models;

public class User
{
    public int Id { get; init; }

    required public string Email { get; set; }
}