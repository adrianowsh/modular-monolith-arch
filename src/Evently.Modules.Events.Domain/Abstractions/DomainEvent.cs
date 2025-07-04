namespace Evently.Modules.Events.Domain.Abstractions;

public abstract class DomainEvent(string id, DateTime occurredAtUtc) : IDomainEvent
{
    private const string EventIdPrefix = $"dvt_";

    protected DomainEvent() : this($"{EventIdPrefix}{Guid.CreateVersion7()}", DateTime.UtcNow)
    {
    }

    public string Id { get; init; } = id;
    public DateTime OccurredAtUtc { get; init; } = occurredAtUtc;
}
