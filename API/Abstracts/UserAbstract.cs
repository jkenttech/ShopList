namespace API.Abstracts;

public abstract class UserAbstract
{
    public int Id { get; init; }

    required public string Email { get; set; }
}