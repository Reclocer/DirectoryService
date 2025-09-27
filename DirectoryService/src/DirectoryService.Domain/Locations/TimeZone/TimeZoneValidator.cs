using FluentValidation;

namespace DirectoryService.Domain.Locations.TimeZone;

public class TimeZoneValidator: AbstractValidator<LocationTimeZone>
{
    public TimeZoneValidator()
    {
        RuleFor(x => x.TimeZoneText)
            .NotEmpty().WithMessage("Time zone cant be empty!")
            .Must(ValidateTimeZone).WithMessage(x => $"TimeZone '{x.TimeZoneText}' invalid.");
    }
    
    private bool ValidateTimeZone(string timeZone)
    {
        if (string.IsNullOrWhiteSpace(timeZone))
            return false;

        try
        {
            TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return true;
        }
        catch (TimeZoneNotFoundException)
        {
            return false;
        }
        catch (InvalidTimeZoneException)
        {
            return false;
        }
    }
}