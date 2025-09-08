using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments;

#pragma warning disable SA1124

public class Department
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Identifier { get; private set; }
    public string Path { get; private set; }
    public short Depth { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateTime { get; private set; }
    public bool IsActive { get; private set; }
    public Guid? ParentId { get; private set; }

    private const int MIN_NAME_LENGTH = 3;
    private const int MAX_NAME_LENGTH = 150;
    
    private const int MIN_IDENTIFIER_LENGTH = 2;
    private const int MAX_IDENTIFIER_LENGTH = 5;
    
    private Department(
        string name,
        string identifier,
        string path,
        short depth,
        DateTime createdAt,
        DateTime updateTime,
        bool isActive = true,
        Guid? parentId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        Path = path;
        Depth = depth;
        CreatedAt = createdAt;
        UpdateTime = updateTime;
        IsActive = isActive;
        ParentId = parentId;
    }

    public Result Rename(string name, string identifier, string path)
    {
        var validatedName = ValidateName(name);
        
        if (!validatedName.IsValid)
            return Result.Failure(validatedName.Message);
    
        Name = name;
        return Result.Success(this);
    }

    public static Result<Department> Create(
        string name,
        string identifier,
        string path,
        short depth,
        DateTime createdAt,
        DateTime updateTime,
        bool isActive = true,
        Guid? parentId = null)
    {
        var validatedName = ValidateName(name);
        
        if (!validatedName.IsValid)
            return Result.Failure<Department>(validatedName.Message);
        
        var validatedIdentifier = ValidateIdentifier(identifier);
        
        if (!validatedIdentifier.IsValid)
            return Result.Failure<Department>(validatedIdentifier.Message);
        
        var validatedPath = ValidatePath(path);
        
        if (!validatedPath.IsValid)
            return Result.Failure<Department>(validatedPath.Message);

        var validatedDepth = ValidateDepth(depth);
        
        if (!validatedDepth.IsValid)
            return Result.Failure<Department>(validatedDepth.Message);

        return Result.Success(new Department(name,
                                             identifier,
                                             path,
                                             depth,
                                             createdAt,
                                             updateTime,
                                             isActive,
                                             parentId));
    }

    #region Validation
    private static (bool IsValid, string Message) ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < MIN_NAME_LENGTH || name.Length > MAX_NAME_LENGTH)
        {
            return (false, $"Name is empty or length < {MIN_NAME_LENGTH} or length > {MAX_NAME_LENGTH}");
        }

        return (true, "isValid");
    }
    
    private static (bool IsValid, string Message) ValidateIdentifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_IDENTIFIER_LENGTH || value.Length > MAX_IDENTIFIER_LENGTH)
        {
            return (false, $"Identifier is empty or length < {MIN_IDENTIFIER_LENGTH} or length > {MAX_IDENTIFIER_LENGTH}");
        }
        
        if (!Regex.IsMatch(value, @"^[a-z_-]+$"))
        {
            return (false, $"Identifier can only consist of (a-z, _-)");
        }

        return (true, "isValid");
    }
    
    private static (bool IsValid, string Message) ValidatePath(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return (false, $"Identifier is empty");
        }
        
        if (!Regex.IsMatch(value, @"^[a-z_-]+$"))
        {
            return (false, $"Identifier can only consist of (a-z, _-)");
        }

        return (true, "isValid");
    }
    
    private static (bool IsValid, string Message) ValidateDepth(short value)
    {
        if(value < 0)
        {
            return (false, "Depth cannot be < 0");
        }

        return (true, "isValid");
    }
    #endregion Validation
}

public class Location
{
    
}