using System.Runtime.Serialization;

namespace VaPe.Common.Handlers.Exceptions;

/// <summary>
/// Exception thrown when entity identifier (ID) is null or empty (eg. Guid.Empty).
/// </summary>
[Serializable]
public class IdentifierNullOrEmptyException : GenericHandlerException
{
    public IdentifierNullOrEmptyException(string message) : base(message)
    {
    }

    protected IdentifierNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

