using Microsoft.Extensions.DependencyInjection;

namespace DI.UnitTests;

public class BasicUnitTests
{
    [Fact]
    public void AddSingleton_ReturnsSameInstance()
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
    public void AddTransient_ReturnsDifferentInstance()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<IServiceA, ServiceA>();
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Act
        IServiceA instance1 = serviceProvider.GetRequiredService<IServiceA>();
        IServiceA instance2 = serviceProvider.GetRequiredService<IServiceA>();

        // Assert
        Assert.NotEqual(instance1, instance2);
    }
    
    [Fact]
    public void AddScoped_SameScope_ReturnsSameInstance()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        services.AddScoped<IServiceA, ServiceA>();
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Act
        using var scope = serviceProvider.CreateScope();
        IServiceA instance1 = scope.ServiceProvider.GetRequiredService<IServiceA>();
        IServiceA instance2 = scope.ServiceProvider.GetRequiredService<IServiceA>();

        // Assert
        Assert.Equal(instance1, instance2);
    }
    
    [Fact]
    public void AddScoped_DifferentScope_ReturnsDifferentInstance()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        services.AddScoped<IServiceA, ServiceA>();
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Act
        using var scope1 = serviceProvider.CreateScope();
        IServiceA instance1 = scope1.ServiceProvider.GetRequiredService<IServiceA>();
        using var scope2 = serviceProvider.CreateScope();
        IServiceA instance2 = scope2.ServiceProvider.GetRequiredService<IServiceA>();

        // Assert
        Assert.NotEqual(instance1, instance2);
    }
    
    [Fact]
    public void GetRequiredService_Unregistered_ThrowsException()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => serviceProvider.GetRequiredService<IServiceA>());
    }
    
    [Fact]
    public void GetService_Unregistered_ReturnsNull()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Act
        IServiceA? instance = serviceProvider.GetService<IServiceA>();
        
        // Assert
        Assert.Null(instance);
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
