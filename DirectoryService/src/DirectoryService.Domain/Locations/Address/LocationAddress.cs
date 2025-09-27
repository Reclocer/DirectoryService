using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.Address;

public record LocationAddress
{
    public readonly string AddressText;

    public readonly string Country;
    public readonly string Region;
    public readonly string City;
    public readonly string Street;
    public readonly string HouseNumber;
    public readonly string Index;
    
    private LocationAddress(
        string country,
        string region,
        string city,
        string street,
        string houseNumber,
        string index)
    {
        Country = country;
        Region = region;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
        Index = index;

        AddressText = $"{country}, {region}, {city}, {street}, {houseNumber}, {index}";
    }

    public static Result<LocationAddress> Create(
        string country,
        string region,
        string city,
        string street,
        string houseNumber,
        string index)
    {
        LocationAddress locationAddress = new LocationAddress(
            country,
            region,
            city,
            street,
            houseNumber,
            index);
        
        var validator = new AddressValidator();
        var result = validator.Validate(locationAddress);

        if (!result.IsValid)
            return Result.Failure<LocationAddress>("Address invalid");

        return Result.Success<LocationAddress>(locationAddress);
    }
}