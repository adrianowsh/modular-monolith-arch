using Evently.Modules.Events.Application.Events.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal sealed class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (string id, ISender sender, CancellationToken cancellationToken) =>
        {
            EventResponse? @event = await sender.Send(new GetEventQuery(id), cancellationToken);

            return @event is null ? Results.NotFound() : Results.Ok(@event);
        })
        .WithTags(Tags.Events);
    }
}
