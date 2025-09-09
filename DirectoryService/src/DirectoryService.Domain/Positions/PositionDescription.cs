using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Positions;

public record PositionDescription
{
    public readonly string? Description;

    private const int MAX_LENGTH = 1000;
    
    private PositionDescription(string? description)
    {
        Description = description;
    }
    
    public static Result<PositionDescription> Create(string description)
    {
        if (description == null)
            return Result.Failure<PositionDescription>("Description is null");
        
        if (description.Length > MAX_LENGTH)
            return Result.Failure<PositionDescription>($"Description length > {MAX_LENGTH}");

        return Result.Success<PositionDescription>(new PositionDescription(description));
    }
}