using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Positions;

public class Position
{
    public Guid Id { get; private set; }
    public PositionName Name { get; private set; } //TODO: Unique
    public PositionDescription Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    private List<DepartmentPosition> _departmentPositions;
    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;
    public bool IsActive { get; private set; }

    private Position(
        Guid id,
        PositionName name,
        PositionDescription description,
        DateTime createdAt,
        List<DepartmentPosition> departmentPositions,
        bool isActive = true)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = createdAt;
        _departmentPositions = departmentPositions;
        IsActive = isActive;
    }

    public static Result<Position> Create(
        Guid id,
        PositionName name,
        PositionDescription description,
        DateTime createdAt,
        List<DepartmentPosition> positions,
        bool isActive = true)
    {
        return Result.Success<Position>(new Position(
            id,
            name,
            description,
            createdAt,
            positions,
            isActive));
    }
}