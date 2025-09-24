using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Positions;

namespace DirectoryService.Infrastructure.Postgres;

public class DirectoryServiceDbContext : DbContext
{
    // private readonly string _connectionString;
    //
    // public DirectoryServiceDbContext(string connectionString)
    // {
    //     _connectionString = connectionString;
    // }
    
    public DirectoryServiceDbContext(DbContextOptions<DirectoryServiceDbContext> options)
        : base(options)
    {
    }
    
    // public DirectoryServiceDbContext()
    // {
    // }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!string.IsNullOrEmpty(_connectionString))
    //     {
    //         optionsBuilder.UseNpgsql(_connectionString);
    //     }
    //     else
    //     {
    //         
    //     }
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<DepartmentId>();
        modelBuilder.Ignore<DepartmentName>();
        modelBuilder.Ignore<Identifier>();
        modelBuilder.Ignore<DepartmentPath>();
        modelBuilder.Ignore<LocationId>();
        modelBuilder.Ignore<LocationName>();
        modelBuilder.Ignore<PositionId>();
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiceDbContext).Assembly);
    }

    public DbSet<Department> GetDepartments()
    {
        return Set<Department>();
    }
    
    public DbSet<Location> GetLocations()
    {
        return Set<Location>();
    }
    
    public DbSet<Position> GetPositions()
    {
        return Set<Position>();
    }
    
    public DbSet<DepartmentLocation> GetDepartmentLocations()
    {
        return Set<DepartmentLocation>();
    }
    
    public DbSet<DepartmentPosition> GetDepartmentPositions()
    {
        return Set<DepartmentPosition>();
    }
}