using DirectoryService.Domain.Locations;
using Microsoft.Extensions.Logging;
using CSharpFunctionalExtensions;
using DirectoryService.Contracts.Location.DTOs;
using DirectoryService.Domain;
using DirectoryService.Domain.Locations.Address;
using DirectoryService.Domain.Locations.TimeZone;

namespace DirectoryService.Application.Locations.Create;

public class CreateLocationHandler
{
    private readonly ILocationsRepository _locationsRepository;
    private readonly ILogger<CreateLocationHandler> _logger;

    public CreateLocationHandler(ILocationsRepository locationsRepository, ILogger<CreateLocationHandler> logger)
    {
        _locationsRepository = locationsRepository;
        _logger = logger;
    }

    public async Task<Result<LocationDTO>> Handle(
        CreateLocationCommand command,
        CancellationToken cancellationToken = default)
    {
        var locationNameResult = LocationName.Create(command.Name);

        if (locationNameResult.IsFailure)
            return Result.Failure<LocationDTO>(locationNameResult.Error);

        var addressResult = LocationAddress.Create(
            command.AddressDto.Country,
            command.AddressDto.Region,
            command.AddressDto.City,
            command.AddressDto.Street,
            command.AddressDto.HouseNumber,
            command.AddressDto.Index);

        if (addressResult.IsFailure)
            return Result.Failure<LocationDTO>(addressResult.Error);
        
        var timeZoneResult = LocationTimeZone.Create(command.TimeZone);

        if (timeZoneResult.IsFailure)
            return Result.Failure<LocationDTO>(timeZoneResult.Error);
        
        var locationResult = Location.Create(
            LocationId.NewId(),
            locationNameResult.Value,
            addressResult.Value,
            timeZoneResult.Value,
            DateTime.UtcNow,
            new List<DepartmentLocation>(),
            true);

        if (locationResult.IsFailure)
            return Result.Failure<LocationDTO>(locationResult.Error);
        
        await _locationsRepository.AddAsync(locationResult.Value, cancellationToken);
        await _locationsRepository.SaveChangesAsync(cancellationToken);
        
        var locationDto = new LocationDTO(
            locationResult.Value.Id,
            locationNameResult.Value.Name,
            command.AddressDto,
            timeZoneResult.Value.TimeZoneText,
            locationResult.Value.CreatedAt,
            locationResult.Value.UpdatedAt,
            locationResult.Value.IsActive);
        
        return Result.Success<LocationDTO>(locationDto);
    }
}