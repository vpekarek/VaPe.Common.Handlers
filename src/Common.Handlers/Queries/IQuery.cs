namespace VaPe.Common.Handlers.Queries;

/// <summary>
/// Marker for query.
/// </summary>
public interface IQuery
{ }

public interface IQuery<TResult> : IQuery
{ }
