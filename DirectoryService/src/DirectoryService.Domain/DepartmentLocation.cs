using DirectoryService.Domain.Departments;

namespace DirectoryService.Domain;

public class DepartmentLocation
{
    public Guid Id { get; private set; }
    public Department Department { get; private set; }
    public Location Location { get; private set; }
    
    public DepartmentLocation(Department department, Location location)
    {
        Id = Guid.NewGuid();
        Department = department;
        Location = location;
    }
}