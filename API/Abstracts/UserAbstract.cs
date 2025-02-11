using System.ComponentModel.DataAnnotations;
namespace API.Abstracts;

public abstract class UserAbstract
{
    public int Id { get; init; }

    [EmailAddress]
    required public string Email { get; set; }
}