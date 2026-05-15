using Microsoft.Extensions.DependencyInjection;

namespace DI.UnitTests;

public class BasicUnitTests
{
    [Fact]
    public void AddSingletone_ReturnsSameInstance()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<IServiceA, ServiceA>();
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Act
        IServiceA instance1 = serviceProvider.GetRequiredService<IServiceA>();
        IServiceA instance2 = serviceProvider.GetRequiredService<IServiceA>();

        // Assert
        Assert.Equal(instance1, instance2);
    }

    [Fact]
    public void Test()
    {
        // Arrange

        // Act

        // Assert
    }

    private interface IServiceA { }
    private sealed class ServiceA : IServiceA { }
}
