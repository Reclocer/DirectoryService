using DirectoryService.Domain.Positions;
using DirectoryService.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class PositionConfiguration: IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder
            .ToTable("position")
            .HasKey(l => l.Id)
            .HasName("pk_positions");

        builder
            .Property(l => l.Id)
            .HasConversion(d => d.Id, id => new PositionId(id))
            .HasColumnName("id");

        builder
            .Property(v => v.Name)
            .HasConversion(v => v.Name, name => PositionName.Create(name).Value)
            .HasColumnName("position_name");

        builder
            .Property(v => v.Description)
            .HasConversion(v => v.Description, description => PositionDescription.Create(description).Value)
            .HasColumnName("description")
            .HasMaxLength(LengthConstants.LENGTH1000);
        
        builder
            .Property(d => d.CreatedAt)
            .HasColumnName("created_at");
        
        builder
            .Property(d => d.UpdatedAt)
            .HasColumnName("updated_at");

        builder
            .HasMany(p => p.DepartmentPositions)
            .WithOne(dp => dp.Position)
            .HasForeignKey(dp => dp.PositionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .Property(v => v.IsActive)
            .HasColumnName("is_active");
    }
}