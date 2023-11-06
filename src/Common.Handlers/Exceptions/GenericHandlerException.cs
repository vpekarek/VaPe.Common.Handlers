using System.Runtime.Serialization;

namespace VaPe.Common.Handlers.Exceptions;

/// <summary>
/// Generic exception.
/// </summary>
[Serializable]
public abstract class GenericHandlerException : Exception
{
    protected GenericHandlerException(string message) : base(message)
    {
    }

    protected GenericHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
