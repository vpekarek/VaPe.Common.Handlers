using Microsoft.Extensions.DependencyInjection;

namespace VaPe.Common.Handlers.UnitTests.Helpers;

public static class DependencyInjectionMoqHelper
{
    public static Mock<IServiceProvider> GetMockedServiceProvider()
    {
        var serviceProvider = new Mock<IServiceProvider>();

        var serviceScope = new Mock<IServiceScope>();
        serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

        var serviceScopeFactory = new Mock<IServiceScopeFactory>();
        serviceScopeFactory
            .Setup(x => x.CreateScope())
            .Returns(serviceScope.Object);

        serviceProvider
            .Setup(x => x.GetService(typeof(IServiceScopeFactory)))
            .Returns(serviceScopeFactory.Object);

        return serviceProvider;
    }
}