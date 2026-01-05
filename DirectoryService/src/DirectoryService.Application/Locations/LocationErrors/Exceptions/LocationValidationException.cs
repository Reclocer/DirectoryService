using DirectoryService.Application.Exceptions;
using DirectoryService.Shared.Errors;

namespace DirectoryService.Application.Locations.LocationErrors.Exceptions;

public class LocationValidationException : BadRequestException
{
    public LocationValidationException(params Error[] errors)
        : base(errors)
    {
    }
}