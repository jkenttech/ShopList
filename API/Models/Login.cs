namespace API.Models;

public class Login : UserAbstract
{
    required public string PasswordHash { get; set; }
}
