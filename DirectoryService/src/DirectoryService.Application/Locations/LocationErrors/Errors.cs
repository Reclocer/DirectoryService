using DirectoryService.Shared.Errors;

namespace DirectoryService.Application.Locations.LocationErrors;

public partial class Errors
{
    public static class Locations
    {
        public static Error ToManyLocations()
        {
            return Error.Failure("location.too.many", "Не может быть более 3-х локаций");
        }
    }
}