using Microsoft.EntityFrameworkCore;
using WhereAmI_API.Database.Configurations;
using WhereAmI_API.Models;

namespace WhereAmI_API.Database.Contexts;

public class MainContext : DbContext
{
    public DbSet<Child> Children { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SafeZone> SafeZones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=dpg-ct8892ggph6c73d3m8r0-a.frankfurt-postgres.render.com;Port=5432;Username=pepega;Password=fxXS5rAzwVbho77jWANdInZ6aX7YGUxH;Database=where_am_i");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ChildConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}