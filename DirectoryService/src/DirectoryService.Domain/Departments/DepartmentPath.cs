using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments;

public record DepartmentPath
{
    public readonly string Path;
    private const string TEXT_PATTERN = @"^[a-z-.]+$";

    private DepartmentPath(string path)
    {
        Path = path;
    }
    
    public static Result<DepartmentPath> Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Result.Failure<DepartmentPath>($"Identifier is empty");
        }
        
        if (!Regex.IsMatch(path, TEXT_PATTERN))
        {
            return Result.Failure<DepartmentPath>($"Identifier can only consist of (a-z, -, .)");
        }

        return Result.Success<DepartmentPath>(new DepartmentPath(path));
    }
}