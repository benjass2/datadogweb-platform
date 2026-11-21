using PC28130.U202422816.Datadog.Platform.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace PC28130.U202422816.Datadog.Platform.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
}