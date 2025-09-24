using DirectoryService.Domain;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentLocationConfiguration: IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder
            .ToTable("department_location")
            .HasKey(l => l.Id)
            .HasName("pk_department_location");
        
        builder
            .Property(l => l.Id)
            .HasColumnName("id");

        builder
            .Property(dl => dl.DepartmentId)
            .HasConversion(d => d.Id, id => new DepartmentId(id))
            .HasColumnName("department_id");
        
        builder
            .Property(dl => dl.LocationId)
            .HasConversion(l => l.Id, id => new LocationId(id))
            .HasColumnName("location_id");

        builder
            .HasOne<Department>()
            .WithMany(d => d.Locations)
            .HasForeignKey(dl => dl.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder
            .HasOne(dl => dl.Location)
            .WithMany(l => l.DepartmentLocations)
            .HasForeignKey(dl => dl.LocationId)
            .IsRequired();
    }
}