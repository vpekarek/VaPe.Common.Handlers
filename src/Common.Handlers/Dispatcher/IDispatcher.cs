using VaPe.Common.Handlers.Queries;
using VaPe.Common.Handlers.Commands;
using VaPe.Common.Handlers.Events;

namespace VaPe.Common.Handlers.Dispatcher;
public interface IDispatcher
{
    /// <summary>
    /// Send a command. The command execution is not real-time.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SendCommandAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;

    /// <summary>
    /// Publish an event. All registered subscribers will be notified and will handle the event unordered.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="event"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PublishEventAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;

    /// <summary>
    /// Run a query to get results.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TResult> QueryResultAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}
