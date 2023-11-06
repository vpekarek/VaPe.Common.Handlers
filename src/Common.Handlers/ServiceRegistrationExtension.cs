using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using VaPe.Common.Handlers.Queries;
using VaPe.Common.Handlers.Events;
using VaPe.Common.Handlers.Dispatcher;
using VaPe.Common.Handlers.Messaging;
using VaPe.Common.Handlers.Commands;

namespace VaPe.Common.Handlers;

[ExcludeFromCodeCoverage]
public static class ServiceRegistrationExtension
{
    /// <summary>
    /// Call AddHttpContextAccessor, AddEndpointsApiExplorer, AddControllers
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSharedFramework(this IServiceCollection services, Action<CommonHandlersOptions> options)
    {
        var config = new CommonHandlersOptions();
        options.Invoke(config);

        if (config.UseEvents)
        {
            services.AddEvents();
        }

        if (config.UseCommandQuery)
        {
            services.AddCommands();
            services.AddQueries();
        }

        if (config.UseMessaging)
        {
            services.AddMessaging();
        }

        var eventDispatcher = config.EventDispatcher ?? typeof(InMemoryDispatcher);
        services.AddSingleton(typeof(IDispatcher), eventDispatcher);
        //services.AddHttpContextAccessor();
        //services.AddEndpointsApiExplorer();
        //services.AddControllers();

        return services;
    }

    ///// <summary>
    ///// Call UseStaticFiles
    ///// </summary>
    ///// <param name="app"></param>
    ///// <returns></returns>
    //public static WebApplication UseSharedFramework(this WebApplication app)
    //{
    //    app.UseStaticFiles();

    //    return app;
    //}
}