using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations.Address;
using DirectoryService.Domain.Locations.TimeZone;

namespace DirectoryService.Domain.Locations;

public class Location
{
    public LocationId Id { get; private set; }
    public LocationName Name { get; private set; }
    public LocationAddress LocationAddress { get; private set; }
    public LocationTimeZone LocationTimeZone { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    private List<DepartmentLocation> _departmentLocations = new();
    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;
    
    public bool IsActive { get; private set; }

    //EF Core
    private Location()
    {
    }
    
    private Location(
        LocationId id,
        LocationName locationName,
        Address.LocationAddress locationAddress,
        TimeZone.LocationTimeZone locationTimeZone,
        DateTime createdAt,
        List<DepartmentLocation> departmentLocations,
        bool isActive = true,
        List<Department> departments = null)
    {
        Id = id;
        Name = locationName;
        LocationAddress = locationAddress;
        LocationTimeZone = locationTimeZone;
        CreatedAt = createdAt;
        UpdatedAt = createdAt;
        _departmentLocations = departmentLocations;
        IsActive = isActive;
    }

    public Result<Location> Create(
        LocationId id,
        LocationName locationName,
        Address.LocationAddress locationAddress,
        TimeZone.LocationTimeZone locationTimeZone,
        DateTime createdAt,
        List<DepartmentLocation> locations,
        bool isActive = true,
        List<Department> departments = null)
    {
        return Result.Success<Location>(new Location(
            id,
            locationName,
            locationAddress,
            locationTimeZone,
            createdAt,
            locations,
            isActive));
    }
}