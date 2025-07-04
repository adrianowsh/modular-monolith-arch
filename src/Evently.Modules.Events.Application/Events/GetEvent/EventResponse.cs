namespace Evently.Modules.Events.Application.Events.GetEvent;

public sealed record EventResponse(
    string Id,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime EndsAtUtc);
