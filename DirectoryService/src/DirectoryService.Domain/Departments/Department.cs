using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments;

public class Department
{
    public DepartmentId Id { get; private set; }
    public DepartmentName Name { get; private set; }
    public Identifier Identifier { get; private set; }
    public DepartmentPath Path { get; private set; }
    public short Depth { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    private List<DepartmentLocation> _locations = new();
    public IReadOnlyList<DepartmentLocation> Locations => _locations;
    
    private List<DepartmentPosition> _positions = new();
    public IReadOnlyList<DepartmentPosition> Positions => _positions;
    
    public bool IsActive { get; private set; }
    public Guid? ParentId { get; private set; }
    
    private List<Department> _children = new();
    public IReadOnlyList<Department> Children => _children;

    //EF Core
    private Department()
    {
    }
    
    private Department(
        DepartmentId departmentId,
        DepartmentName name,
        Identifier identifier,
        DepartmentPath path,
        short depth,
        DateTime createdAt,
        List<DepartmentLocation> locations,
        List<DepartmentPosition> positions,
        bool isActive = true,
        Guid? parentId = null,
        List<Department> children = null)
    {
        Id = departmentId;
        Name = name;
        Identifier = identifier;
        Path = path;
        Depth = depth;
        CreatedAt = createdAt;
        UpdateAt = createdAt;
        _locations = locations;
        _positions = positions;
        IsActive = isActive;
        ParentId = parentId;
        _children = children;
    }
    
    public static Result<Department> Create(
        DepartmentId departmentId,
        DepartmentName name,
        Identifier identifier,
        DepartmentPath path,
        short depth,
        DateTime createdAt,
        List<DepartmentLocation> locations,
        List<DepartmentPosition> positions,
        bool isActive = true,
        Guid? parentId = null,
        List<Department> children = null)
    {
        var validatedDepth = ValidateDepth(depth);
        
        if (!validatedDepth.IsValid)
            return Result.Failure<Department>(validatedDepth.Message);
        
        if(locations == null || locations.Count == 0)
            return Result.Failure<Department>("Locations is empty");

        return Result.Success(new Department(departmentId,
                                             name,
                                             identifier,
                                             path,
                                             depth,
                                             createdAt,
                                             locations,
                                             positions,
                                             isActive,
                                             parentId,
                                             children));
    }
    
    public void Rename(DepartmentName name, Identifier identifier, DepartmentPath path, DateTime updateTime)
    {
        Name = name;
        Identifier = identifier;
        Path = path;
        UpdateAt = updateTime;
        //TODO: change path in children
    }
    
    private static (bool IsValid, string Message) ValidateDepth(short value)
    {
        if(value < 0)
        {
            return (false, "Depth cannot be < 0");
        }

        return (true, "isValid");
    }
}