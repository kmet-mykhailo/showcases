namespace IdempotentApiDemo.AppContracts.Models.Commands;

public interface IIdempotentCommand
{
    public string IdempotencyKey { get; }
    public string CommandName { get; } 
}