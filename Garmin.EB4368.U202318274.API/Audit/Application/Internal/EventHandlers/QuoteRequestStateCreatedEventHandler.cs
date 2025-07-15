using Cortex.Mediator.Notifications;
using Garmin.EB4368.U202318274.API.Audit.Domain.Model.Events;
using Garmin.EB4368.U202318274.API.Shared.Application.Internal.EventHandlers;

namespace Garmin.EB4368.U202318274.API.Audit.Application.Internal.EventHandlers;

public class QuoteRequestStateCreatedEventHandler : IEventHandler<QuoteRequestStateCreatedEvent>
{
    public Task Handle(QuoteRequestStateCreatedEvent domainCreatedEvent, CancellationToken cancellationToken)
    {
        return On(domainCreatedEvent);
    }

    public Task On(QuoteRequestStateCreatedEvent domainEvent)
    {
        Console.WriteLine("Created Thing: {0}", domainEvent.QuoteRequestId);
        return Task.CompletedTask;
    }
}