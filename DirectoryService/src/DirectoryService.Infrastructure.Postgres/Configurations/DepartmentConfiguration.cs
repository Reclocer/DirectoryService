using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DirectoryService.Domain.Departments;
using DirectoryService.Shared;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentConfiguration: IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .ToTable("departments")
            .HasKey(d => d.Id).HasName("pk_departments");

        builder
            .Property(d => d.Id)
            .HasConversion(d => d.Id, id => new DepartmentId(id))
            .HasColumnName("id");
        
        builder
            .Property(d => d.Name)
            .HasConversion(d => d.Name, name => DepartmentName.Create(name).Value)
            .HasColumnName("name")
            .HasMaxLength(LengthConstants.LENGTH150);
        
        builder
            .Property(d => d.Identifier)
            .HasConversion(d => d.Value, identifier => Identifier.Create(identifier).Value)
            .HasColumnName("identifier");

        builder
            .Property(d => d.Path)
            .HasConversion(d => d.Path, path => DepartmentPath.Create(path).Value)
            .HasColumnName("path");
        
        builder
            .Property(d => d.Depth)
            .HasColumnName("depth");

        builder
            .Property(d => d.CreatedAt)
            .HasColumnName("created_at");
        
        builder
            .Property(d => d.UpdateAt)
            .HasColumnName("updated_at");
        
        builder
            .HasMany(d => d.Locations)
            .WithOne()
            .HasForeignKey(dl => dl.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder
            .HasMany(d => d.Positions)
            .WithOne()
            .HasForeignKey(dp => dp.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .Property(d => d.IsActive)
            .HasColumnName("is_active");
        
        builder
            .Property(d => d.ParentId)
            .HasConversion(
                d => d == null ? (Guid?)null : d.Id,
                id => id == null ? null : new DepartmentId(id.Value))
            .HasColumnName("parent_id")
            .IsRequired(false);
        
        builder
            .HasMany(d => d.Children)
            .WithOne()
            .HasForeignKey(d => d.ParentId)
            .HasPrincipalKey(d => d.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}