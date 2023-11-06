using System.Runtime.Serialization;

namespace VaPe.Common.Handlers.Exceptions;

/// <summary>
/// Exception thrown when <seealso cref="Commands.ICommand"/> is null.
/// </summary>
[Serializable]
public class CommandNullException : GenericHandlerException
{
    public CommandNullException(string message) : base(message)
    {
    }

    protected CommandNullException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

