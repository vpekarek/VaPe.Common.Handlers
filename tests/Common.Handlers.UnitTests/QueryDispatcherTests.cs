using VaPe.Common.Handlers.Exceptions;
using VaPe.Common.Handlers.Queries;
using VaPe.Common.Handlers.UnitTests.Helpers;

namespace VaPe.Common.Handlers.UnitTests;

public sealed class QueryDispatcherTests
{
    private Mock<IServiceProvider> _mockServiceProvider;
    private QueryDispatcher _queryDispatcher;

    [SetUp]
    public void SetUp()
    {
        _mockServiceProvider = DependencyInjectionMoqHelper.GetMockedServiceProvider();
        _queryDispatcher = new QueryDispatcher(_mockServiceProvider.Object);
    }

    [Test]
    public void QueryDispatcher_Constructor()
    {
        // Arrange + Act
        var queryDispatcher = new QueryDispatcher(_mockServiceProvider.Object);

        // Assert
        queryDispatcher.Should().NotBeNull();
    }

    [Test]
    public void SendAsync_WhenQueryIsNull_Throws_QueryNullException()
    {
        // Arrange
        TestQuery @event = null!;

        // Act + Assert
        Assert.ThrowsAsync<QueryNullException>(async () => await _queryDispatcher.QueryAsync(@event, default));
    }

    [Test]
    public void SendAsync_WhenQueryValid_NoHandler_Throws()
    {
        // Arrange
        TestQuery @event = new();

        // Act + Assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _queryDispatcher.QueryAsync(@event, default));
    }

    [Test]
    public void SendAsync_WhenQueryValid_WithHandler_NotThrowException()
    {
        // Arrange
        TestQuery @event = new();
        _mockServiceProvider
            .Setup(x => x.GetService(typeof(IQueryHandler<TestQuery, TestQueryResult>)))
            .Returns(new TestQueryHandler());

        _mockServiceProvider
            .Setup(x => x.GetService(typeof(IEnumerable<IQueryHandler<TestQuery, TestQueryResult>>)))
            .Returns(new[] { new TestQueryHandler() });


        // Act + Assert
        Assert.DoesNotThrowAsync(async () => await _queryDispatcher.QueryAsync(@event, default));
    }

    public class TestQuery : IQuery<TestQueryResult> { }
    public record TestQueryResult(DateTime date);

    public class TestQueryHandler : IQueryHandler<TestQuery, TestQueryResult>
    {
        public Task<TestQueryResult> HandleAsync(TestQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new TestQueryResult(DateTime.Now));
        }
    }
}