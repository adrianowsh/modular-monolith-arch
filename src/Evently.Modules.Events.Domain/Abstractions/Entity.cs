namespace Evently.Modules.Events.Domain.Abstractions;

public abstract class Entity 
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public string Id { get; protected set; }

    public DateTime InsertedAtUtc { get; protected set; }

    public DateTime? UpdatedAtUtc { get; set; }

    protected Entity(string id)
    {
        Id = id;
        InsertedAtUtc = DateTime.UtcNow;
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
