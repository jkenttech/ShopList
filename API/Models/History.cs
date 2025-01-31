namespace API.Models;

public class History
{
    public int Id { get; set; }

    public int RelatedId { get; set; }

    public DateTime UpdateTime { get; init; }

    public string PreviousField { get; init; } = string.Empty;

    public string PreviousValue { get; init; } = string.Empty;
}