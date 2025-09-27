using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;

namespace DirectoryService.Domain;

public class DepartmentLocation
{
    public Guid Id { get; private set; }
    public DepartmentId DepartmentId { get; private set; }
    public LocationId LocationId { get; private set; }
    public Location Location { get; private set; }

    public DepartmentLocation()
    {
    }

    public DepartmentLocation(DepartmentId departmentId, LocationId locationId)
    {
        Id = Guid.NewGuid();
        DepartmentId = departmentId;
        LocationId = locationId;
    }
}