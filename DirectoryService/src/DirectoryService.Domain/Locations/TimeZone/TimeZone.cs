using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.TimeZone;

public record TimeZone
{
    public readonly string TimeZoneText;

    private TimeZone(string timeZoneText)
    {
        TimeZoneText = timeZoneText;
    }

    public Result<TimeZone> Create(string timeZoneText)
    {
        TimeZone timeZone = new TimeZone(timeZoneText);
        
        var validator = new TimeZoneValidator();
        var result = validator.Validate(timeZone);

        if (!result.IsValid)
            return Result.Failure<TimeZone>("TimeZone invalid");

        return Result.Success<TimeZone>(timeZone);
    }
}