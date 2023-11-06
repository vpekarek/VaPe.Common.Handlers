using VaPe.Common.Handlers.Messaging;
using Microsoft.Extensions.Logging;
using VaPe.Common.Handlers.Events;
using VaPe.Common.Handlers.Exceptions;

namespace VaPe.Common.Handlers.UnitTests;

public class InMemoryMessageBrokerTests
{
    private Mock<IAsyncEventDispatcher> _mockEventDispatcher;
    private Mock<ILogger<InMemoryMessageBroker>> _mockLogger;
    private InMemoryMessageBroker _messageBroker;

    [SetUp]
    public void SetUp()
    {
        _mockEventDispatcher = new Mock<IAsyncEventDispatcher>();
        _mockLogger = new Mock<ILogger<InMemoryMessageBroker>>();
        _messageBroker = new InMemoryMessageBroker(_mockEventDispatcher.Object, _mockLogger.Object);
    }

    [Test]
    public void InMemoryMessageBroker_Constructor()
    {
        // Arrange + Act
        var broker = new InMemoryMessageBroker(_mockEventDispatcher.Object, _mockLogger.Object);

        // Assert
        broker.Should().NotBeNull();
    }

    [Test]
    public void PublishAsync_WhenEventIsNull_Throws_EventNullException()
    {
        // Arrange
        IEvent @event = null!;


        // Act + Assert
        Assert.ThrowsAsync<EventNullException>(async () => await _messageBroker.PublishAsync(@event, default));
    }

    [Test]
    public async Task PublishAsync_WhenEventIsValid_PublishEvent()
    {
        // Arrange
        IEvent @event = new TestEvent(1);

        // Act
        await _messageBroker.PublishAsync(@event, default);

        // Assert
        _mockEventDispatcher.Verify(x => x.PublishAsync(@event, default), Times.Once());
    }

    private record TestEvent(int Index) : IEvent;
}
