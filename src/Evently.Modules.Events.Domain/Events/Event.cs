using Evently.Modules.Events.Domain.Abstractions;
using Evently.Modules.Events.Domain.Events.Events;

namespace Evently.Modules.Events.Domain.Events;

public sealed class Event : Entity
{
    private const string EventIdPrefix = "evt_";

    private Event(
        string id,
        string title,
        string description,
        string location,
        DateTime startsAtUtc,
        DateTime endsAtUtc) : base(id)
    {
        Id = id;
        Title = title;
        Description = description;
        Location = location;
        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;
    }
 
    public string Title { get; private set; }

    public string Description{ get; private set; }

    public string Location { get; private set; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime EndsAtUtc { get; private set; }

    public EventStatus Status { get; private set; }

    public static Event Create(
        string title,
        string description,
        string location,
        DateTime startsAtUtc,
        DateTime endAtUtc)
    {
        var @event =  new Event(
            id: NewEventId,
            title: title,
            description: description,
            location: location,
            startsAtUtc: startsAtUtc,
            endsAtUtc: endAtUtc)
        {
            Status = EventStatus.Draft
        };

        @event.Raise(new EventCreatedDomainEvent(@event.Id));

        return @event;
    }

    private static string NewEventId => $"{EventIdPrefix}{Guid.CreateVersion7()}";
}
