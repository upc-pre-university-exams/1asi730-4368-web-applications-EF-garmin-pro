using Cortex.Mediator.Notifications;

namespace Garmin.EB4368.U202318274.API.Shared.Domain.Model.Events;
/// <summary>
/// Represents a domain event in the system.
/// </summary>
/// <remarks>
/// This interface is used to mark classes as domain events that can be published and handled by the event bus.
/// It extends from <see cref="INotification"/> to integrate with the mediator pattern for event handling.
/// </remarks> 
public interface IEvent : INotification
{
    
}