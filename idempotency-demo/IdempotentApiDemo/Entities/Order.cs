namespace IdempotentApiDemo.Entities;

public sealed class Order
{
    public long Id { get; init; }
    public Guid Key { get; init; }
    public string? Name { get; init; }
}