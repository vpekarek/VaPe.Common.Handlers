using VaPe.Common.Handlers.Exceptions;
using VaPe.Common.Handlers.Commands;
using VaPe.Common.Handlers.Events;
using VaPe.Common.Handlers.Queries;

namespace VaPe.Common.Handlers.Extensions;
public static class GuardExtensions
{
    /// <summary>
    /// Guard that <paramref name="query"/> is not null.
    /// </summary>
    /// <param name="query">Query to guard.</param>
    /// <exception cref="Exceptions.QueryNullException">Throws when null.</exception>
    public static void GuardNotNull(this IQuery query)
    {
        _ = query ?? throw new QueryNullException("Query can't be null.");
    }

    /// <summary>
    /// Guard that <paramref name="command"/> is not null.
    /// </summary>
    /// <param name="command">Command to guard.</param>
    /// <exception cref="Exceptions.CommandNullException">Throws when null.</exception>
    public static void GuardNotNull(this ICommand command)
    {
        _ = command ?? throw new CommandNullException("Command can't be null.");
    }

    /// <summary>
    /// Guard that <paramref name="event"/> is not null.
    /// </summary>
    /// <param name="event">Event to guard.</param>
    /// <exception cref="Exceptions.EventNullException">Throws when null.</exception>
    public static void GuardNotNull(this IEvent @event)
    {
        _ = @event ?? throw new EventNullException("Event can't be null.");
    }

    /// <summary>
    /// Guard that <paramref name="guid"/> is not Empty.
    /// </summary>
    /// <param name="guid">Guid to guard.</param>
    /// <exception cref="Exceptions.IdentifierNullOrEmptyException"></exception>
    public static void GuardNotEmpty(this Guid guid)
    {
        if (guid == Guid.Empty)
        {
            throw new IdentifierNullOrEmptyException("Identifier can't be null or empty Guid.");
        }
    }
}
