using VaPe.Common.Handlers.Commands;
using VaPe.Common.Handlers.Exceptions;
using VaPe.Common.Handlers.UnitTests.Helpers;

namespace VaPe.Common.Handlers.UnitTests;
internal sealed class CommandDispatcherTests
{
    private Mock<IServiceProvider> _mockServiceProvider;
    private CommandDispatcher _commandDispatcher;

    [SetUp]
    public void SetUp()
    {
        _mockServiceProvider = DependencyInjectionMoqHelper.GetMockedServiceProvider();
        _commandDispatcher = new CommandDispatcher(_mockServiceProvider.Object);
    }

    [Test]
    public void CommandDispatcher_Constructor()
    {
        // Arrange + Act
        var commandDispatcher = new CommandDispatcher(_mockServiceProvider.Object);

        // Assert
        commandDispatcher.Should().NotBeNull();
    }

    [Test]
    public void SendAsync_WhenCommandIsNull_Throws_CommandNullException()
    {
        // Arrange
        TestCommand command = null!;

        // Act + Assert
        Assert.ThrowsAsync<CommandNullException>(async () => await _commandDispatcher.SendAsync(command, default));
    }

    [Test]
    public void SendAsync_WhenCommandValid_NoHandler_Throw_InvalidOperationException()
    {
        // Arrange
        TestCommand command = new();

        // Act + Assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _commandDispatcher.SendAsync(command, default));
    }

    [Test]
    public void SendAsync_WhenCommandValid_WithHandler_NotThrowException()
    {
        // Arrange
        TestCommand command = new();
        _mockServiceProvider
            .Setup(x => x.GetService(typeof(ICommandHandler<TestCommand>)))
            .Returns(new TestCommandHandler());

        // Act + Assert
        Assert.DoesNotThrowAsync(async () => await _commandDispatcher.SendAsync(command, default));
    }

    internal class TestCommand : ICommand { }

    internal class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public Task HandleAsync(TestCommand command, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
