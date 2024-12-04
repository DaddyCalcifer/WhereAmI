using Microsoft.EntityFrameworkCore;
using WhereAmI_API.Database.Contexts;
using WhereAmI_API.Models;

namespace WhereAmI_API.Services;

public class ChildService()
{

    public async Task<Child> CreateChild(string deviceId)
    {
        var child = new Child();
        child.DeviceId = deviceId;
        child.ParentId = null;
        child.Parent = null;
        await using (var context = new MainContext())
        {
            context.Children.Add(child);
            await context.SaveChangesAsync();
            return child;
        }
    }

    public async Task<Child?> GetById(Guid id)
    {
        await using (var context = new MainContext())
        {
            return await context.Children
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
    public async Task<Child?> GetByDeviceId(string id)
    {
        await using (var context = new MainContext())
        {
            return await context.Children
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.DeviceId == id);
        }
    }
}