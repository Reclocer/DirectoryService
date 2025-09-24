using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.TimeZone;

public record LocationTimeZone
{
    public readonly string TimeZoneText;

    private LocationTimeZone(string timeZoneText)
    {
        TimeZoneText = timeZoneText;
    }

    public static Result<LocationTimeZone> Create(string timeZoneText)
    {
        LocationTimeZone locationTimeZone = new LocationTimeZone(timeZoneText);
        
        var validator = new TimeZoneValidator();
        var result = validator.Validate(locationTimeZone);

        if (!result.IsValid)
            return Result.Failure<LocationTimeZone>("TimeZone invalid");

        return Result.Success<LocationTimeZone>(locationTimeZone);
    }
}