using DirectoryService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class PositionConfiguration: IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder
            .ToTable("position")
            .HasKey(l => l.Id).HasName("id");

        builder
            .Property(l => l.Id)
            .HasConversion(d => d.Value, id => new PositionId(id));
    }
}