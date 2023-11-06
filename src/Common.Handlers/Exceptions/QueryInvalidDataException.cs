using System.Runtime.Serialization;

namespace VaPe.Common.Handlers.Exceptions;

/// <summary>
/// Exception thrown when <seealso cref="Queries.IQuery"/> contain invalid data (eg. null string that don't allow nulls, empty string when data is required, ...)
/// </summary>
[Serializable]
public class QueryInvalidDataException : GenericHandlerException
{
    public QueryInvalidDataException(string message) : base(message)
    {
    }

    protected QueryInvalidDataException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
