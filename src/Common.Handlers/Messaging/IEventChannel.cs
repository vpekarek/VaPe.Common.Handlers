using System.Threading.Channels;
using VaPe.Common.Handlers.Events;

namespace VaPe.Common.Handlers.Messaging;

internal interface IEventChannel
{
    ChannelReader<IEvent> Reader { get; }
    ChannelWriter<IEvent> Writer { get; }
}

