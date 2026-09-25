using AsyncAwaitDemo.Core;

namespace UnitTests;

public class AsyncAwaitUnitTests
{
    [Fact]
    public void DoSomethingWithExceptionAsync_WhenNotAwaited_DoesNotThrow()
    {
        // Act
        AsyncAwaitCases.DoSomethingWithExceptionAsync();
        
        // Assert
        Assert.True(true);
    }
    
    [Fact]
    public async Task DoSomethingWithExceptionAsync_WhenAwaited_Throw()
    {
        // Act && Assert
        var exception =  await Assert.ThrowsAsync<Exception>(() => AsyncAwaitCases.DoSomethingWithExceptionAsync());
        Assert.NotNull(exception);
    }
    
    [Fact]
    public async Task DoSomethingWithExceptionAsync_WhenNotAwaitedTryCatch_MissExceptionThrown()
    {
        // Arrange
        Task NotAwaitedTryCatch()
        {
            try
            {
                return AsyncAwaitCases.DoSomethingWithExceptionAsync();
            }
            catch(Exception ex)
            {
                // never catch exception
                return Task.FromResult(ex.Message);
            }
        }
        
        // Act & Assert
        await Assert.ThrowsAsync<Exception>(NotAwaitedTryCatch);
    }
    
    [Fact]
    public async Task DoSomethingWithExceptionAsync_WhenNotAwaitedUsing_MissExceptionThrown()
    {
        // Arrange
        Task NotAwaitedUsing()
        {
            using var cancellationTokenSource = new CancellationTokenSource();
            return AsyncAwaitCases.DoSomethingWithExceptionAsync(cancellationTokenSource.Token);
        }
        
        // Act & Assert
        await Assert.ThrowsAsync<Exception>(NotAwaitedUsing);
    }
}