namespace WhereAmI_API.Models.Requests;

public class AddChildRequest
{
    public Guid ParentId { get; set; }
    public Guid ChildId { get; set; }
}