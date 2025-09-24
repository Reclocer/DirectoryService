namespace DirectoryService.Domain.Locations;

public record LocationId
{
    public Guid Id { get; }

    private LocationId()
    {
        Id = Guid.NewGuid();
    }
    
    public LocationId(Guid id)
    {
        Id = id;
    }
    
    public static LocationId NewId() => new();
    
    public static implicit operator Guid(LocationId locationId) => locationId.Id;
    public static implicit operator LocationId(Guid id) => new(id);
}