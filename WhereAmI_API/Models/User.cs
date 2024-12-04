using System.ComponentModel.DataAnnotations;

namespace WhereAmI_API.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(70)] 
    public string DeviceId { get; set; } = "";
    public ICollection<Child?> Children { get; set; } = new List<Child?>();
    public ICollection<SafeZone?> SafeZones { get; set; } = new List<SafeZone?>();

    public User()
    {
    }

    public User(string deviceId)
    {
        this.DeviceId = deviceId;
    }
}