using VaPe.Common.Handlers.Events;

namespace VaPe.Common.Handlers.Messaging;

public interface IMessageBroker
{
    Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
}

