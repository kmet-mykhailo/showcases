namespace AsyncAwaitDemo.Core;

public static class AsyncAwaitCases
{
    public static async Task DoSomethingWithExceptionAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);
        throw new Exception();
    }
}