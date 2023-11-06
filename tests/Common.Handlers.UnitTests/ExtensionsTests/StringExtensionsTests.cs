using VaPe.Common.Handlers.Extensions;

namespace VaPe.Common.Handlers.UnitTests.ExtensionsTests;

internal sealed class StringExtensionsTests
{
    [Test]
    public void IsNotEmpty_WhenEmpty_ReturnsFalse()
    {
        // Arrange
        string testValue = string.Empty;

        // Act
        var result = testValue.IsNotEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void IsNotEmpty_WhenNull_ReturnsFalse()
    {
        // Arrange
        string? testValue = null;

        // Act
        var result = testValue.IsNotEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void IsNotEmpty_WhenWhiteSpace_ReturnsFalse()
    {
        // Arrange
        string testValue = " ";

        // Act
        var result = testValue.IsNotEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void IsNotEmpty_WhenNotEmpty_ReturnsTrue()
    {
        // Arrange
        string testValue = "This is not empty string.";

        // Act
        var result = testValue.IsNotEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void IsEmpty_WhenEmpty_ReturnsTrue()
    {
        // Arrange
        string testValue = "";

        // Act
        var result = testValue.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void IsEmpty_WhenNull_ReturnsTrue()
    {
        // Arrange
        string? testValue = null;

        // Act
        var result = testValue.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void IsEmpty_WhenWhiteSpace_ReturnsTrue()
    {
        // Arrange
        string testValue = " ";

        // Act
        var result = testValue.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void IsEmpty_WhenNotEmpty_ReturnsFalse()
    {
        // Arrange
        string testValue = "This is not empty.";

        // Act
        var result = testValue.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }
}
