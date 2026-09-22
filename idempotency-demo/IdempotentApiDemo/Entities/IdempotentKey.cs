namespace IdempotentApiDemo.Entities;

public class IdempotentKey
{
    public Guid Id { get; init; }
    public Guid Key { get; init; }
    public int Type { get; init; }
    public DateTime CreatedOn { get; init; }
}