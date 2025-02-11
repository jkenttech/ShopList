using API.Models;

namespace API.DTOs;

public class RegisterDTO : UserAbstract
{
    required public string Password { get; set; }
    required public string PasswordConfirm { get; set; }
}