using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments;

public record Identifier
{
    public readonly string IdentifierValue;
    
    private const int MIN_IDENTIFIER_LENGTH = 2;
    private const int MAX_IDENTIFIER_LENGTH = 8;
    private const string TEXT_PATTERN = @"^[a-z-]+$";

    private Identifier(string identifierValue)
    {
        IdentifierValue = identifierValue;
    }
    
    public static Result<Identifier> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)
         || value.Length < MIN_IDENTIFIER_LENGTH
         || value.Length > MAX_IDENTIFIER_LENGTH)
        {
            return Result.Failure<Identifier>($"Identifier is empty or length < {MIN_IDENTIFIER_LENGTH} or length > {MAX_IDENTIFIER_LENGTH}");
        }
        
        if (!Regex.IsMatch(value, TEXT_PATTERN))
        {
            return Result.Failure<Identifier>($"Identifier can only consist of (a-z, -)");
        }

        return Result.Success<Identifier>(new Identifier(value));
    }
}