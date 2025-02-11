using API.Abstracts;
using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class User : UserAbstract
{
    [StringLength(96, MinimumLength = 1, ErrorMessage = "FirstNames must be between {2} and {1} characters in length.")]
    required public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ProfilePicture { get; set; }

    public AccountType AccountType { get; set; } = AccountType.Disabled;
}
