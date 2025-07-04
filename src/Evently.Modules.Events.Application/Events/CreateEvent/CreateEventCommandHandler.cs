using Evently.Modules.Events.Application.Abstractions;
using Evently.Modules.Events.Domain.Events;
using MediatR;

namespace Evently.Modules.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateEventCommand, string>
{
    public async Task<string> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = Event.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndAtUtc);

        eventRepository.Insert(@event);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return @event.Id;
    }
}



