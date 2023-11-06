﻿namespace VaPe.Common.Handlers.Commands;

internal interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand;
}
