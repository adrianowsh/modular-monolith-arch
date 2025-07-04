﻿using System.Data.Common;
using Dapper;
using Evently.Modules.Events.Application.Abstractions;
using MediatR;

namespace Evently.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(string EventId) : IRequest<EventResponse?>;

internal sealed class GetEventQueryCommandHandler(IDbConnectionFactory dbConnectionFactory) : IRequestHandler<GetEventQuery, EventResponse?>
{
    public async Task<EventResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql = 
            $"""
             SELECT 
                id AS {nameof(EventResponse.Id)},
                title AS {nameof(EventResponse.Title)},
                description AS {nameof(EventResponse.Description)},
                location AS {nameof(EventResponse.Location)},
                starts_at_utc AS {nameof(EventResponse.StartsAtUtc)},
                ends_at_utc AS {nameof(EventResponse.EndsAtUtc)}
              FROM events.events
              WHERE id = @EventId;
             """;

        EventResponse? @event = await connection.QuerySingleOrDefaultAsync(sql, request);

        return @event;
    }
}


