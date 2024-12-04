using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereAmI_API.Models;

namespace WhereAmI_API.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Children)
            .WithOne(x => x!.Parent);
        builder.HasMany(x => x.SafeZones)
            .WithOne(x => x!.Owner);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.HasIndex(e => e.DeviceId).IsUnique();
    }
}