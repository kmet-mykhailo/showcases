namespace UnitTests;

public class AsyncAwaitExceptionsUnitTests
{
    [Fact]
    public void AwaitException_WhenNotAwaited_DoesNotThrow()
    {
        // Act
        AwaitExceptionAsync();
        
        // Assert
        Assert.True(true);
    }
    
    [Fact]
    public async Task AwaitException_WhenAwaited_Throw()
    {
        // Act && Assert
        var exception =  await Assert.ThrowsAsync<Exception>(AwaitExceptionAsync);
        Assert.NotNull(exception);
    }
    
    private static async Task AwaitExceptionAsync()
    {
        await Task.Delay(100);
        throw new Exception();
    }
}