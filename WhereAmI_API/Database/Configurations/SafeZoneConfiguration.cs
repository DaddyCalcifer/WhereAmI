using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereAmI_API.Models;

namespace WhereAmI_API.Database.Configurations;

public class SafezoneConfiguration : IEntityTypeConfiguration<SafeZone>
{
    public void Configure(EntityTypeBuilder<SafeZone> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Owner)
            .WithMany(x => x.SafeZones)
            .HasForeignKey(x => x.OwnerId);
    }
}