using DirectoryService.Domain;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder
            .ToTable("department_position")
            .HasKey(l => l.Id)
            .HasName("pk_department_position");
        
        builder
            .Property(dp => dp.Id)
            .HasColumnName("id");

        builder
            .Property(dl => dl.DepartmentId)
            .HasConversion(d => d.Id, id => new DepartmentId(id))
            .HasColumnName("department_id");
        
        builder
            .Property(dp => dp.PositionId)
            .HasConversion(p => p.Id, id => new PositionId(id))
            .HasColumnName("position_id");

        builder
            .HasOne<Department>()
            .WithMany(d => d.Positions)
            .HasForeignKey(dp => dp.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder
            .HasOne(dp => dp.Position)
            .WithMany(p => p.DepartmentPositions) 
            .HasForeignKey(dp => dp.PositionId)
            .IsRequired();
    }
}