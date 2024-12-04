using System.ComponentModel.DataAnnotations;

namespace WhereAmI_API.Models;

public class SafeZone
{
    public Guid Id { get; set; }
    [MaxLength(40)]
    public string Name { get; set; } = "Безопасная зона N";
    public int Color { get; set; } = 0;
    [MaxLength(500)]
    public string Location { get; set; } = "";
    public float Radius { get; set; } = 0;
    public Guid? OwnerId { get; set; }
    public User? Owner { get; set; }
}