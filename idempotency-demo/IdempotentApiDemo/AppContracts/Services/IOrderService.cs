using IdempotentApiDemo.AppContracts.Models.Commands;
using IdempotentApiDemo.AppContracts.Models.Results;

namespace IdempotentApiDemo.AppContracts.Services;

public interface IOrderService
{
    Task<OrderResult> CreateOrderAsync(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken);
}