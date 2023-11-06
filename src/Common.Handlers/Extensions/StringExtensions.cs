using System.Diagnostics.CodeAnalysis;

namespace VaPe.Common.Handlers.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Check the string value if it is null or white space.
    /// </summary>
    /// <param name="value">String value to verify.</param>
    /// <returns></returns>
    public static bool IsEmpty([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Check the string value if it is not null or white space.
    /// </summary>
    /// <param name="value">String value to verify.</param>
    /// <returns></returns>
    public static bool IsNotEmpty([NotNullWhen(true)] this string? value) => !value.IsEmpty();
}