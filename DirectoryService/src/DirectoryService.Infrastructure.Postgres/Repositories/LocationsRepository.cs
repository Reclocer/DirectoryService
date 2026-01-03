using CSharpFunctionalExtensions;
using DirectoryService.Application.Locations;
using DirectoryService.Domain.Locations;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrastructure.Postgres.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly DirectoryServiceDbContext _dbContext;
    private readonly ILogger<LocationsRepository> _logger;

    public LocationsRepository(DirectoryServiceDbContext context, ILogger<LocationsRepository> logger)
    {
        _dbContext = context;
        _logger = logger;
    }

    public async Task<Result<Guid>> AddAsync(Location location, CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.GetLocations().AddAsync(location, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Result.Success<Guid>(location.Id.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding location {id}", location.Id);
            return Result.Failure<Guid>(e.Message);
        }
    }

    public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.SaveChangesAsync();
            return Result.Success("Saved");
        }
        catch (Exception e)
        {
            return Result.Failure($"Location repository save changes error {e}");
        }
    }
}