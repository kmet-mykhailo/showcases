using IdempotentApiDemo.AppContracts.Models.Commands;

namespace IdempotentApiDemo.AppContracts.Repositories;

public interface IIdempotentKeyRepository<TResult> where TResult : class?
{
    Task AddAsync(IIdempotentCommand idempotentCommand, CancellationToken cancellationToken);
    Task UpdateAsync(IIdempotentCommand idempotentCommand, TResult result, CancellationToken cancellationToken);
    Task<TResult?> GetAsync(IIdempotentCommand idempotentCommand, CancellationToken cancellationToken);
}