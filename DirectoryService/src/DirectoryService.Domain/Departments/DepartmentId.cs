namespace DirectoryService.Domain.Departments;

public record DepartmentId
{
    public Guid Id { get; }

    private DepartmentId()
    {
        Id = Guid.NewGuid();
    }
    
    public DepartmentId(Guid id)
    {
        Id = id;
    }

    public static DepartmentId NewId() => new();
    
    public static implicit operator Guid(DepartmentId departmentId) => departmentId.Id;
    public static implicit operator DepartmentId(Guid id) => new(id);
}