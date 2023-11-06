using VaPe.Common.Handlers.Events;
using VaPe.Common.Handlers.Extensions;

namespace VaPe.Common.Handlers.Messaging;
internal sealed class AsyncEventDispatcher : IAsyncEventDispatcher
{
    private readonly IEventChannel _channel;

    public AsyncEventDispatcher(IEventChannel channel)
    {
        _channel = channel;
    }

    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent
    {
        @event.GuardNotNull();
        await _channel.Writer.WriteAsync(@event, cancellationToken);
    }
}