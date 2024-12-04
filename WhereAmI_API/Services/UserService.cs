using Microsoft.EntityFrameworkCore;
using WhereAmI_API.Database.Contexts;
using WhereAmI_API.Models;

namespace WhereAmI_API.Services;

public class UserService()
{

    public async Task<User> CreateUser(User user)
    {
        user.Children = new List<Child>()!;
        await using (var context = new MainContext())
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
    
    public async Task<List<User>> GetAll()
    {
        await using (var context = new MainContext())
        {
            return await context.Users
                .AsNoTracking()
                .Include(x => x.Children)
                .Include(x => x.SafeZones)
                .ToListAsync();
        }
    }

    public async Task<User?> GetById(Guid? id)
    {
        await using (var context = new MainContext())
        {
            return await context.Users
                .Include(u => u.Children)
                .Include(x => x.SafeZones)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
    public async Task<User?> GetById_lite(Guid id)
    {
        await using (var context = new MainContext())
        {
            return await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
    
    public async Task<bool> AddChild(Guid userId, Child child)
    {
        await using(var context = new MainContext())
        {
            var user = await context.Users.FirstOrDefaultAsync(c => c.Id == userId);
            
            if (user == null) return false;
            
            user.Children.Add(child);
            context.Users.Update(user);
            
            await context.SaveChangesAsync();
        }
        return true;
    }
    public async Task<bool> AddSafeZone(SafeZone safeZone)
    {
        await using(var context = new MainContext())
        {
            var user = await context
                .Users
                .Include(u => u.SafeZones)
                .FirstOrDefaultAsync(c => c.Id == safeZone.OwnerId);
            
            if (user == null) return false;
            
            user.SafeZones.Add(safeZone);
            context.Users.Update(user);
            
            await context.SaveChangesAsync();
        }
        return true;
    }
}