using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;
using VaPe.Common.Handlers.Events;

namespace VaPe.Common.Handlers.Messaging;

[ExcludeFromCodeCoverage]
internal sealed class EventChannel : IEventChannel
{
    private readonly Channel<IEvent> _messages = Channel.CreateUnbounded<IEvent>();

    public ChannelReader<IEvent> Reader => _messages.Reader;
    public ChannelWriter<IEvent> Writer => _messages.Writer;
}

