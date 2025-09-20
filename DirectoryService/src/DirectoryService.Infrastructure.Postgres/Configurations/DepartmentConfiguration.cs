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
            .HasKey(d => d.Id).HasName("id");

        builder
            .Property(d => d.Id)
            .HasConversion(d => d.Value, id => new DepartmentId(id));
        
        builder.OwnsOne(v => v.Name, nb =>
        {
            nb.Property(d => d.Name)
              .HasMaxLength(LengthConstants.LENGTH500)
              .HasColumnName("name");
        });

        builder.Navigation(v => v.Name).IsRequired(false);
    }
}