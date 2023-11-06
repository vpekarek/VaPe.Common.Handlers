using System.Runtime.Serialization;

namespace VaPe.Common.Handlers.Exceptions;

/// <summary>
/// Exception thrown when <seealso cref="Queries.IQuery"/> is null.
/// </summary>
[Serializable]
public class QueryNullException : GenericHandlerException
{
    public QueryNullException(string message) : base(message)
    {
    }

    protected QueryNullException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
