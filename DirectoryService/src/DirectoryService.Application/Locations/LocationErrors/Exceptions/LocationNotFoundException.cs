using DirectoryService.Application.Exceptions;
using DirectoryService.Shared.Errors;

namespace DirectoryService.Application.Locations.LocationErrors.Exceptions;

public class LocationNotFoundException : NotFoundException
{
    public LocationNotFoundException(params Error[] errors)
        : base(errors)
    {
    }
}