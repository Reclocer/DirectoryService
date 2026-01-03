namespace DirectoryService.Contracts.Location.DTOs;

public record AddressDTO(
    string Country,
    string Region,
    string City,
    string Street,
    string HouseNumber,
    string Index);