﻿using Microsoft.Extensions.DependencyInjection;

namespace VaPe.Common.Handlers.Queries;

internal static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
           .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
           .AsImplementedInterfaces()
           .WithScopedLifetime());

        return services;
    }
}