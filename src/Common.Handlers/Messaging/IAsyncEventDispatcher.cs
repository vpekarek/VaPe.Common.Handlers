using VaPe.Common.Handlers.Events;

namespace VaPe.Common.Handlers.Messaging;

internal interface IAsyncEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent;
}

