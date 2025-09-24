using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DirectoryService.Infrastructure.Postgres;

public class DirectoryServiceDbContextFactory : IDesignTimeDbContextFactory<DirectoryServiceDbContext>
{
    public DirectoryServiceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DirectoryServiceDbContext>();
        
        optionsBuilder.UseNpgsql("Server=localhost;Port=5434;Database=directory_service_db;User Id=postgres;Password=postgres;");

        return new DirectoryServiceDbContext(optionsBuilder.Options);
    }
}