using Cortex.Mediator.Notifications;

namespace Garmin.EB4368.U202318274.API.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : INotification
{
}