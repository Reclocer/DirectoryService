namespace DirectoryService.Domain.Positions;

public record PositionId
{
    public Guid Id { get; }

    private PositionId()
    {
        Id = Guid.NewGuid();
    }
    
    public PositionId(Guid id)
    {
        Id = id;
    }
    
    public static PositionId NewId() => new();
    
    // Implicit conversion operators для удобства работы с Guid
    public static implicit operator Guid(PositionId positionId) => positionId.Id;
    public static implicit operator PositionId(Guid id) => new(id);
}