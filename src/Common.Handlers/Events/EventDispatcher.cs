using Microsoft.Extensions.DependencyInjection;
using VaPe.Common.Handlers.Extensions;

namespace VaPe.Common.Handlers.Events;

internal sealed class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent
    {
        if (@event is null)
        {
            return;
        }

        if (typeof(TEvent) == typeof(IEvent))
        {
            await PublishDynamicallyAsync(@event, cancellationToken);
            return;
        }

        using var scope = _serviceProvider.CreateScope();
        var isAnyHandler = scope.ServiceProvider.GetService<IEventHandler<TEvent>>() != null;

        if (!isAnyHandler)
        {
            return;
        }

        var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();

        if (handlers is null)
        {
            return;
        }

        @event.GuardNotNull();
        var tasks = handlers.Select(x => x.HandleAsync(@event, cancellationToken));
        await Task.WhenAll(tasks);
    }

    private async Task PublishDynamicallyAsync(IEvent @event, CancellationToken cancellationToken = default)
    {
        @event.GuardNotNull();
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
        var handlers = scope.ServiceProvider.GetServices(handlerType);
        var method = handlerType.GetMethod(nameof(IEventHandler<IEvent>.HandleAsync));

        if (method is null)
        {
            throw new InvalidOperationException($"Event handler for '{@event.GetType().Name}' is invalid.");
        }

        var tasks = handlers
                        .Select(x => (Task?)method.Invoke(x, new object[] { @event, cancellationToken }))
                        .OfType<Task>();
        await Task.WhenAll(tasks);

    }
}
