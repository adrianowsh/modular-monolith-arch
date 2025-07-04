using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events.Events;

public sealed class EventCreatedDomainEvent(string eventId) : DomainEvent
{
    public string EventId { get; init; } = eventId;
}
