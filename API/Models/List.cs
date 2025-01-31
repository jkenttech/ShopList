namespace API.Models;

public class List
{
    public int Id { get; }

    public DateTime DateAdded { get; }

    public DateTime DateModified { get; set; }

    public string ListName { get; set; } = "new list";
}