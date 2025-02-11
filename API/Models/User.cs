using API.Abstracts;
namespace API.Models;

public class User : UserAbstract
{
    required public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ProfilePicture { get; set; }

    public string? AccountType { get; set; }
}
