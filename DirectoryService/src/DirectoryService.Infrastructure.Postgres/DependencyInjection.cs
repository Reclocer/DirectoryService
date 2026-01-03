using DirectoryService.Application.Locations;
using DirectoryService.Infrastructure.Postgres.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryService.Infrastructure.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddDataBase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ILocationsRepository, LocationsRepository>();
        return services;
    }
}