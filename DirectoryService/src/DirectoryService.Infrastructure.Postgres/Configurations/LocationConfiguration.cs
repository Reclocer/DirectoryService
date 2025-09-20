using DirectoryService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class LocationConfiguration: IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .ToTable("locations")
            .HasKey(l => l.Id).HasName("id");

        builder
            .Property(l => l.Id)
            .HasConversion(d => d.Value, id => new LocationId(id));
    }
}