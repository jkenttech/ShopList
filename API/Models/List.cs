namespace API.Models;

public class List
{
    public int Id { get; }

    public int OwnerId { get; set; }
    
    public int? SharedId { get; set; }
    
    public int? ShopId { get; set; }

    public DateTime DateAdded { get; }

    public DateTime? DateModified { get; set; }

    public string ListName { get; set; } = "new list";

    public string Description { get; set; } = "list description";
}