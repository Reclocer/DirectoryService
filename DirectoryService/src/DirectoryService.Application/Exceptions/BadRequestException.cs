using System.Text.Json;
using DirectoryService.Shared.Errors;

namespace DirectoryService.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(params Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {
    }
}