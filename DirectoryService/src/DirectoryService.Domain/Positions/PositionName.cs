using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Positions;

public record PositionName
{
    //TODO: Unique
    public readonly string Name;
    
    private const int MIN_LENGTH = 3;
    private const int MAX_LENGTH = 100;

    private PositionName(string name)
    {
        Name = name;
    }
    
    public static Result<PositionName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name)
            || name.Length < MIN_LENGTH
            || name.Length > MAX_LENGTH)
        {
            return Result.Failure<PositionName>($"Name is empty or length < {MIN_LENGTH} or length > {MAX_LENGTH}");
        }

        return Result.Success<PositionName>(new PositionName(name));
    }
}