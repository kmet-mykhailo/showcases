using IdempotentApiDemo.Entities;

namespace IdempotentApiDemo.AppContracts.Repositories;

public interface IOrderRepository
{
    Task<Order> AddAsync(string orderName);
}