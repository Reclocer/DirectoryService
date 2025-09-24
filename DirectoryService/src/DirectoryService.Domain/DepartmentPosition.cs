using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Positions;

namespace DirectoryService.Domain;

public class DepartmentPosition
{
    public Guid Id { get; private set; }
    public DepartmentId DepartmentId { get; private set; }
    public PositionId PositionId { get; private set; }
    public Position Position { get; private set; }

    public DepartmentPosition()
    {
    }
    
    public DepartmentPosition(DepartmentId departmentId, PositionId positionId)
    {
        Id = Guid.NewGuid();
        DepartmentId = departmentId;
        PositionId = positionId;
    }
}