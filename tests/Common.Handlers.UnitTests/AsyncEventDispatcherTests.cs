using VaPe.Common.Handlers.Messaging;
using VaPe.Common.Handlers.Events;
using VaPe.Common.Handlers.Exceptions;

namespace VaPe.Common.Handlers.UnitTests;

public class AsyncEventDispatcherTests
{
    private Mock<IEventChannel> _mockChannel;

    [SetUp]
    public void SetUp()
    {
        _mockChannel = new Mock<IEventChannel>();
    }

    [Test]
    public void AsyncEventDispatcher_Constructor()
    {
        // Arrange + Act
        var asyncEventDispatcher = new AsyncEventDispatcher(_mockChannel.Object);

        // Assert
        asyncEventDispatcher.Should().NotBeNull();
    }

    [Test]
    public void PublishAsync_WhenEventNull_Throws_EventNullException()
    {
        // Arrange
        var asyncEventDispatcher = new AsyncEventDispatcher(_mockChannel.Object);
        IEvent @event = null!;

        // Act + Assert
        Assert.ThrowsAsync<EventNullException>(async () => await asyncEventDispatcher.PublishAsync(@event, default));
    }
}