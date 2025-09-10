using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments;

public record DepartmentName
{
    public readonly string Name;
    
    private const int MIN_LENGTH = 3;
    private const int MAX_LENGTH = 150;

    private DepartmentName(string name)
    {
        Name = name;
    }
    
    public static Result<DepartmentName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name)
         || name.Length < MIN_LENGTH
         || name.Length > MAX_LENGTH)
        {
            return Result.Failure<DepartmentName>($"Name is empty or length < {MIN_LENGTH} or length > {MAX_LENGTH}");
        }

        return Result.Success<DepartmentName>(new DepartmentName(name));
    }
}