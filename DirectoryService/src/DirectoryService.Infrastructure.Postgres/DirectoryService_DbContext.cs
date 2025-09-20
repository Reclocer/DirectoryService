using Microsoft.EntityFrameworkCore;
using DirectoryService.Domain.Departments;

namespace DirectoryService.Infrastructure.Postgres;

public class DirectoryService_DbContext : DbContext
{
    private readonly string _connectionString;

    public DirectoryService_DbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryService_DbContext).Assembly);
    }

    public DbSet<Department> Departments()
    {
        return Set<Department>();
    }
}