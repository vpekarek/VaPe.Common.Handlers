using VaPe.Common.Handlers.Commands;
using VaPe.Common.Handlers.Events;
using VaPe.Common.Handlers.Exceptions;
using VaPe.Common.Handlers.Extensions;
using VaPe.Common.Handlers.Queries;

namespace VaPe.Common.Handlers.UnitTests.ExtensionsTests;

internal sealed class GuardExtensionsTests
{
    [Test]
    public void GuardNotNull_Query_WhenNull_Throws_QueryNullException()
    {
        // Arrange
        IQuery value = null!;

        // Act + Assert
        Assert.Throws<QueryNullException>(value.GuardNotNull);
    }

    [Test]
    public void GuardNotNull_Query_WhenNotNull_Success()
    {
        // Arrange
        IQuery value = new TestQuery(1);

        // Act + Assert
        Assert.DoesNotThrow(value.GuardNotNull);
    }

    [Test]
    public void GuardNotNull_Command_WhenNull_Throws_CommandNullException()
    {
        // Arrange
        ICommand value = null!;

        // Act + Assert
        Assert.Throws<CommandNullException>(value.GuardNotNull);
    }

    [Test]
    public void GuardNotNull_Command_WhenNotNull_Success()
    {
        // Arrange
        ICommand value = new TestCommand(1);

        // Act + Assert
        Assert.DoesNotThrow(value.GuardNotNull);
    }

    [Test]
    public void GuardNotNull_Event_WhenNull_Throws_EventNullException()
    {
        // Arrange
        IEvent value = null!;

        // Act + Assert
        Assert.Throws<EventNullException>(value.GuardNotNull);
    }

    [Test]
    public void GuardNotNull_Event_WhenNotNull_Success()
    {
        // Arrange
        IEvent value = new TestEvent(1);

        // Act + Assert
        Assert.DoesNotThrow(value.GuardNotNull);
    }

    private record TestQuery(int Index) : IQuery;
    private record TestCommand(int Index) : ICommand;
    private record TestEvent(int Index) : IEvent;
}
