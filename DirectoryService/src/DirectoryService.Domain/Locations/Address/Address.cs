using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.Address;

public record Address
{
    public readonly string AddressText;

    public readonly string Country;
    public readonly string Region;
    public readonly string City;
    public readonly string Street;
    public readonly string HouseNumber;
    public readonly string Index;
    
    private Address(
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

    public Result<Address> Create(
        string country,
        string region,
        string city,
        string street,
        string houseNumber,
        string index)
    {
        Address address = new Address(
            country,
            region,
            city,
            street,
            houseNumber,
            index);
        
        var validator = new AddressValidator();
        var result = validator.Validate(address);

        if (!result.IsValid)
            return Result.Failure<Address>("Address invalid");

        return Result.Success<Address>(address);
    }
}