using System.Text.Json;
using DirectoryService.Shared.Errors;

namespace DirectoryService.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(params Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {
    }
}