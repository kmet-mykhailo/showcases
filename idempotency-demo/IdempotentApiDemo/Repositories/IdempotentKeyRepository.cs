using IdempotentApiDemo.AppContracts.Models.Commands;
using IdempotentApiDemo.AppContracts.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace IdempotentApiDemo.Repositories;

public class IdempotentKeyRepository<TResult>(IMemoryCache keys) : IIdempotentKeyRepository<TResult> where TResult : class?
{
    private const int IdempotencyWindowInSeconds = 12;

    private readonly Dictionary<string, Dictionary<string, (object? Result, DateTime? CreatedOn)>> _keys = new()
        {
            { nameof(CreateOrderCommand), new Dictionary<string, (object?,  DateTime?)>() },
        };


    public Task AddAsync(IIdempotentCommand idempotentCommand, CancellationToken cancellationToken)
    {
        var key = $"{idempotentCommand.CommandName}:{idempotentCommand.IdempotencyKey}";
        var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(IdempotencyWindowInSeconds));
        keys.Set<TResult?>(key, null, cacheOptions);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(IIdempotentCommand idempotentCommand, TResult result, CancellationToken cancellationToken)
    {
        var key = $"{idempotentCommand.CommandName}:{idempotentCommand.IdempotencyKey}";
        var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(IdempotencyWindowInSeconds));
        keys.Set(key, result, cacheOptions);
        return Task.CompletedTask;
    }
    
    public Task<TResult?> GetAsync(IIdempotentCommand idempotentCommand, CancellationToken cancellationToken)
    {
        var key = $"{idempotentCommand.CommandName}:{idempotentCommand.IdempotencyKey}";
        return keys.TryGetValue<TResult>(key, out var result) 
            ? Task.FromResult(result) 
            : Task.FromResult<TResult?>(null);
    }
}