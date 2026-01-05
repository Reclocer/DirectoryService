using DirectoryService.Application.Exceptions;

namespace DirectoryService.Application.Locations.LocationErrors.Exceptions;

public class ToManyLocationsException : BadRequestException
{
    public ToManyLocationsException()
        : base([Errors.Locations.ToManyLocations()])
    {
    }
}