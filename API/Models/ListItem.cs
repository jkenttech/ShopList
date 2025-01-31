namespace API.Models;

public class ListItem
{
    public int Id { get; }
    
    public int ListId { get; set; }

    public DateTime DateAdded { get; }

    public DateTime DateModified { get; set; }

    public string Description { get; set; } = "new item";

    public virtual List? AssociatedList { get; set; }
}