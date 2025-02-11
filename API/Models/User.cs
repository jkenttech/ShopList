namespace API.Models;

public class User : UserAbstract
{
    required public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ProfilePicture { get; set; }

    required public string AccountType { get; set; }
}

public abstract class UserAbstract
{
    public int Id { get; init; }

    required public string Email { get; set; }
}