using DirectoryService.Contracts.Location.DTOs;

namespace DirectoryService.Application.Locations.Create;

public record CreateLocationCommand(
    string Name,
    AddressDTO AddressDto,
    string TimeZone);