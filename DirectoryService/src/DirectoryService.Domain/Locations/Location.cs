using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;

namespace DirectoryService.Domain.Locations;

public class Location
{
    public Guid Id { get; private set; }
    public LocationName Name { get; private set; }
    public Address.Address Address { get; private set; }
    public TimeZone.TimeZone TimeZone { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    private List<DepartmentLocation> _departmentLocations;
    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;
    
    public bool IsActive { get; private set; }
    
    private List<Department> _departments;
    public IReadOnlyList<Department> Departments => _departments;

    private Location(
        Guid id,
        LocationName locationName,
        Address.Address address,
        TimeZone.TimeZone timeZone,
        DateTime createdAt,
        List<DepartmentLocation> departmentLocations,
        bool isActive = true,
        List<Department> departments = null)
    {
        Id = id;
        Name = locationName;
        Address = address;
        TimeZone = timeZone;
        CreatedAt = createdAt;
        UpdatedAt = createdAt;
        _departmentLocations = departmentLocations;
        IsActive = isActive;
        _departments = departments;
    }

    public Result<Location> Create(
        Guid id,
        LocationName locationName,
        Address.Address address,
        TimeZone.TimeZone timeZone,
        DateTime createdAt,
        List<DepartmentLocation> locations,
        bool isActive = true,
        List<Department> departments = null)
    {
        return Result.Success<Location>(new Location(
            id,
            locationName,
            address,
            timeZone,
            createdAt,
            locations,
            isActive,
            departments));
    }
}