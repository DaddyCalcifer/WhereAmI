namespace WhereAmI_API.Models;
using System.ComponentModel.DataAnnotations;
public class Child
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(70)]
    public string DeviceId { get; set; } = "";
    [MaxLength(500)]
    public string Location { get; set; } = "";
    
    public Guid? ParentId { get; set; }
    public User? Parent { get; set; }
}