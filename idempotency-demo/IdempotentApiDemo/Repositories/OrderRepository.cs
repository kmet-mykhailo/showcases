using IdempotentApiDemo.AppContracts.Repositories;
using IdempotentApiDemo.Entities;

namespace IdempotentApiDemo.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly Dictionary<long, Order> _orders = new();

    public Task<Order> AddAsync(string orderName)
    {
        var id = _orders.Count + 1;
        var order = new Order { Id = id, Key = Guid.NewGuid(), Name = orderName };
        _orders.Add(id, order);
        return Task.FromResult(order);
    }
}