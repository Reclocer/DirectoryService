namespace DirectoryService.Contracts.Location.DTOs;

public record LocationDTO(
    Guid Id,
    string Name,
    AddressDTO Address,
    string Timezone,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    bool IsActive);