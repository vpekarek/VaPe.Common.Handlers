using System.Runtime.Serialization;

namespace VaPe.Common.Handlers.Exceptions;

/// <summary>
/// Exception thrown when <seealso cref="Events.IEvent"/> is null.
/// </summary>
[Serializable]
public class EventNullException : GenericHandlerException
{
    public EventNullException(string message) : base(message)
    {
    }

    protected EventNullException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

