using IdempotentApiDemo.AppContracts.Models.Commands;
using IdempotentApiDemo.AppContracts.Models.Results;
using IdempotentApiDemo.AppContracts.Repositories;
using IdempotentApiDemo.AppContracts.Services;

namespace IdempotentApiDemo.Services;

/// <summary>
/// Service for working with orders.
/// </summary>
/// <param name="idempotentKeyRepository">Idempotency key repository.</param>
/// <param name="orderRepository">Order repository.</param>
public class OrderService(
    IIdempotentKeyRepository<OrderResult> idempotentKeyRepository,
    IOrderRepository  orderRepository)
: IOrderService
{
    public async Task<OrderResult> CreateOrderAsync(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken)
    {
        // check if the same command has already been executed
        // TODO: add retries for added key but not updated yet
        var result = await idempotentKeyRepository.GetAsync(createOrderCommand, cancellationToken);
        
        if (result != null)
        {
            return result;
        }
        
        // add command to repository for idempotent key
        await idempotentKeyRepository.AddAsync(createOrderCommand, cancellationToken);
        
        // save order
        var order = await orderRepository.AddAsync(createOrderCommand.Details);
        
        // create new result
        result = new OrderResult(order.Key, order.Name);
        
        // update result in repository for idempotent key
        await idempotentKeyRepository.UpdateAsync(createOrderCommand, result,  cancellationToken);
        return result;
    }
}