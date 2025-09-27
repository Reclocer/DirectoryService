using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Locations.TimeZone;
using DirectoryService.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class LocationConfiguration: IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .ToTable("locations")
            .HasKey(l => l.Id)
            .HasName("pk_locations");

        builder
            .Property(l => l.Id)
            .HasConversion(d => d.Id, id => new LocationId(id))
            .HasColumnName("id");
        
        builder
            .Property(d => d.Name)
            .HasConversion(d => d.Name, name => LocationName.Create(name).Value)
            .HasColumnName("name")
            .HasMaxLength(LengthConstants.LENGTH120);

        builder.ComplexProperty(a => a.LocationAddress, addressBuilder =>
        {
            addressBuilder
                .Property(c => c.Country)
                .HasColumnName("country")
                .HasMaxLength(LengthConstants.LENGTH50)
                .IsRequired();

            addressBuilder
                .Property(c => c.Region)
                .HasColumnName("region")
                .HasMaxLength(LengthConstants.LENGTH50)
                .IsRequired();

            addressBuilder
                .Property(c => c.City)
                .HasColumnName("city")
                .HasMaxLength(LengthConstants.LENGTH50)
                .IsRequired();

            addressBuilder
                .Property(c => c.Street)
                .HasColumnName("street")
                .HasMaxLength(LengthConstants.LENGTH50)
                .IsRequired();

            addressBuilder
                .Property(c => c.HouseNumber)
                .HasColumnName("house_number")
                .HasMaxLength(LengthConstants.LENGTH50)
                .IsRequired();

            addressBuilder
                .Property(c => c.Index)
                .HasColumnName("index")
                .HasMaxLength(LengthConstants.LENGTH50)
                .IsRequired();
        });
        
        builder
            .Property(d => d.LocationTimeZone)
            .HasConversion(d => d.TimeZoneText, timeZone => LocationTimeZone.Create(timeZone).Value)
            .HasColumnName("time_zone")
            .HasMaxLength(LengthConstants.LENGTH120);

        builder
            .Property(d => d.CreatedAt)
            .HasColumnName("created_at");
        
        builder
            .Property(d => d.UpdatedAt)
            .HasColumnName("updated_at");
        
        builder
            .HasMany(l => l.DepartmentLocations)
            .WithOne(dl => dl.Location)
            .HasForeignKey(dl => dl.LocationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .Property(v => v.IsActive)
            .HasColumnName("is_active");
    }
}