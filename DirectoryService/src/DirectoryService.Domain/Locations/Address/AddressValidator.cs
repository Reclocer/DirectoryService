using FluentValidation;

namespace DirectoryService.Domain.Locations.Address;

public class AddressValidator: AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100).WithMessage("Country is too long.");

        RuleFor(x => x.Region)
            .MaximumLength(100).WithMessage("Region is too long.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .Matches(@"^[\p{L}\s\-]+$").WithMessage("City name contains invalid characters.");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required.")
            .MaximumLength(200).WithMessage("Street name is too long.");

        RuleFor(x => x.HouseNumber)
            .NotEmpty().WithMessage("House number is required.")
            .MaximumLength(20).WithMessage("House number is too long.");

        RuleFor(x => x.Index)
            .NotEmpty().WithMessage("Postal code is required.")
            .Matches(@"^\d{4,10}$").WithMessage("Postal code must be 4–10 digits.");
    }
}