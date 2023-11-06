using VaPe.Common.Handlers.Events;
using VaPe.Common.Handlers.UnitTests.Helpers;

namespace VaPe.Common.Handlers.UnitTests;

public sealed class EventDispatcherTests
{
    private Mock<IServiceProvider> _mockServiceProvider;
    private EventDispatcher _eventDispatcher;

    [SetUp]
    public void SetUp()
    {
        _mockServiceProvider = DependencyInjectionMoqHelper.GetMockedServiceProvider();
        _eventDispatcher = new EventDispatcher(_mockServiceProvider.Object);
    }

    [Test]
    public void EventDispatcher_Constructor()
    {
        // Arrange + Act
        var eventDispatcher = new EventDispatcher(_mockServiceProvider.Object);

        // Assert
        eventDispatcher.Should().NotBeNull();
    }

    [Test]
    public void SendAsync_WhenEventIsNull_NotThrowException()
    {
        // Arrange
        TestEvent @event = null!;

        // Act + Assert
        Assert.DoesNotThrowAsync(async () => await _eventDispatcher.PublishAsync(@event, default));
    }

    [Test]
    public void SendAsync_WhenEventValid_NoHandler_NotThrowException()
    {
        // Arrange
        TestEvent @event = new();

        // Act + Assert
        Assert.DoesNotThrowAsync(async () => await _eventDispatcher.PublishAsync(@event, default));
    }

    [Test]
    public void SendAsync_WhenEventValid_WithHandler_NotThrowException()
    {
        // Arrange
        TestEvent @event = new();
        _mockServiceProvider
            .Setup(x => x.GetService(typeof(IEventHandler<TestEvent>)))
            .Returns(new TestEventHandler());

        _mockServiceProvider
            .Setup(x => x.GetService(typeof(IEnumerable<IEventHandler<TestEvent>>)))
            .Returns(new[] { new TestEventHandler() });


        // Act + Assert
        Assert.DoesNotThrowAsync(async () => await _eventDispatcher.PublishAsync(@event, default));
    }

    [Test]
    public async Task SendAsync_WhenEventValid_WithMultipleHandlers_HandlersAreCalled()
    {
        // Arrange
        TestEvent @event = new();
        var eventHandlerMock = new Mock<TestEventHandler>();
        var eventHandler = eventHandlerMock.Object;
        eventHandlerMock
            .Setup(x => x.HandleAsync(It.IsAny<TestEvent>(), default))
            .Returns(Task.CompletedTask);
        _mockServiceProvider
            .Setup(x => x.GetService(typeof(IEventHandler<TestEvent>)))
            .Returns(eventHandler);

        _mockServiceProvider
            .Setup(x => x.GetService(typeof(IEnumerable<IEventHandler<TestEvent>>)))
            .Returns(new[] { eventHandler, eventHandler });

        // Act
        await _eventDispatcher.PublishAsync(@event, default);

        // Assert
        eventHandlerMock.Verify(x => x.HandleAsync(It.IsAny<TestEvent>(), default), Times.Exactly(2));
    }

    public class TestEvent : IEvent { }

    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public virtual Task HandleAsync(TestEvent @event, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
