using API.Models;

namespace API.DTOs;

public class RegisterDTO : User
{
    required public string Password { get; set; }
    required public string PasswordConfirm { get; set; }
}